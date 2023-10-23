using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using CODEx.Model.View_Models;
using CODEx.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CODEx.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Events> eventList = _unitOfWork.Event.GetAll();
            IEnumerable<Coordinator> coordinatorList = _unitOfWork.Coordinator.GetAll();
            var viewModel = new ListVM
            {
                Events = eventList,
                Coordinators = coordinatorList
            };

            return View(viewModel);
        }

        public IActionResult Details(int eventId)
        {
            Events events = _unitOfWork.Event.Get(u => u.Id == eventId);
            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
