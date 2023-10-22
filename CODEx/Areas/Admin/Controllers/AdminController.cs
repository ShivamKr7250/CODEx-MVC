using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using CODEx.Model.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace CODEx.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Events> objEventList = _unitOfWork.Event.GetAll().ToList();
            return View(objEventList);
        }

        public IActionResult Upsert(int? id)
        {

            EventVM eventVM = new()
            {
                Event = new Events()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(eventVM);
            }
            else
            {
                //Update
                eventVM.Event = _unitOfWork.Event.Get(u => u.Id == id);
                return View(eventVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EventVM eventVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\event");

                    if (!string.IsNullOrEmpty(eventVM.Event.PosterUrl))
                    {
                        //delete th old Image
                        var oldImagePath = Path.Combine(wwwRootPath, eventVM.Event.PosterUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    eventVM.Event.PosterUrl = @"\images\event\" + fileName;
                }

                if (eventVM.Event.Id == 0)
                {
                    _unitOfWork.Event.Add(eventVM.Event);
                }
                else
                {
                    _unitOfWork.Event.Update(eventVM.Event);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(eventVM);
            }
        }
    }
}
