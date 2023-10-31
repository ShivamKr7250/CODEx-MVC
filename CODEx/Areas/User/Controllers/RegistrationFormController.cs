using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using Microsoft.AspNetCore.Mvc;

namespace CODEx.Areas.User.Controllers
{
    [Area("User")]
    public class RegistrationFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegistrationFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<RegistrationForm> objRegistrationList = _unitOfWork.RegistrationForm.GetAll().ToList();
            return View(objRegistrationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegistrationForm obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RegistrationForm.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Minithon", "Home");
            }
            return View();

        }
    }
}
