using Microsoft.AspNetCore.Mvc;

namespace CODEx.Areas.User.Controllers
{
    public class RegistrationFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
