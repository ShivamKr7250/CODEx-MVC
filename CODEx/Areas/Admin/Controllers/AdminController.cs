using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using CODEx.Model.View_Models;
using CODEx.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CODEx.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
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

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Multiple Ways to Retrieve Data and Edit 

            Events? eventFromDb = _unitOfWork.Event.Get(u => u.Id == id); //Find work only on primary key
                                                                                  // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
                                                                                  // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (eventFromDb == null)
            {
                return NotFound();
            }
            return View(eventFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Events obj = _unitOfWork.Event.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Event.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Event Deleted Successfully";
            return RedirectToAction("Index", "Admin");
        }
    }
}
