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
    public class FacultyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FacultyController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Faculty> objFacultyList = _unitOfWork.Faculty.GetAll().ToList();
            return View(objFacultyList);
        }

        public IActionResult Upsert(int? id)
        {
            FacultyVM facultyVM = new()
            {
                Faculty = new Faculty()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(facultyVM);
            }
            else
            {
                //Update
                facultyVM.Faculty = _unitOfWork.Faculty.Get(u => u.Id == id);
                return View(facultyVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(FacultyVM facultyVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\faculty");

                    if (!string.IsNullOrEmpty(facultyVM.Faculty.ImageUrl))
                    {
                        //delete th old Image
                        var oldImagePath = Path.Combine(wwwRootPath, facultyVM.Faculty.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    facultyVM.Faculty.ImageUrl = @"\images\faculty\" + fileName;
                }

                if (facultyVM.Faculty.Id == 0)
                {
                    _unitOfWork.Faculty.Add(facultyVM.Faculty);
                }
                else
                {
                    _unitOfWork.Faculty.Update(facultyVM.Faculty);
                }
                _unitOfWork.Save();
                TempData["success"] = "Faculty Added Successfully";
                return RedirectToAction("Index", "Faculty");
            }
            else
            {
                return View(facultyVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Multiple Ways to Retrieve Data and Edit 

            Faculty? facultyFromDb = _unitOfWork.Faculty.Get(u => u.Id == id); //Find work only on primary key
                                                                          // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
                                                                          // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (facultyFromDb == null)
            {
                return NotFound();
            }
            return View(facultyFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Faculty obj = _unitOfWork.Faculty.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Faculty.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Faculty Deleted Successfully";
            return RedirectToAction("Index", "Faculty");
        }
    }
}
