using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model.View_Models;
using CODEx.Model;
using Microsoft.AspNetCore.Mvc;
using CODEx.Utility;
using Microsoft.AspNetCore.Authorization;

namespace CODEx.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoordinatorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoordinatorController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Coordinator> objCoordinatorList = _unitOfWork.Coordinator.GetAll().ToList();
            return View(objCoordinatorList);
        }

        public IActionResult Upsert(int? id)
        {
            CoordinatorVM coordinatorVM = new()
            {
                Coordinator = new Coordinator()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(coordinatorVM);
            }
            else
            {
                //Update
                coordinatorVM.Coordinator = _unitOfWork.Coordinator.Get(u => u.Id == id);
                return View(coordinatorVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CoordinatorVM coordinatorVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\coordinator");

                    if (!string.IsNullOrEmpty(coordinatorVM.Coordinator.ImageUrl))
                    {
                        //delete th old Image
                        var oldImagePath = Path.Combine(wwwRootPath, coordinatorVM.Coordinator.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    coordinatorVM.Coordinator.ImageUrl = @"\images\coordinator\" + fileName;
                }

                if (coordinatorVM.Coordinator.Id == 0)
                {
                    _unitOfWork.Coordinator.Add(coordinatorVM.Coordinator);
                }
                else
                {
                    _unitOfWork.Coordinator.Update(coordinatorVM.Coordinator);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index", "Coordinator");
            }
            else
            {
                return View(coordinatorVM);
            }
        }
    }
}
