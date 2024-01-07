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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ListCoordinator()
        {
            IEnumerable<Coordinator> coordinatorList = _unitOfWork.Coordinator.GetAll();
            return View(coordinatorList);
        }

        public IActionResult ListEvents()
        {
            IEnumerable<Events> eventsList = _unitOfWork.Event.GetAll();
            return View(eventsList);
        }


        public IActionResult CoordinatorDetails(int? coordinatorId)
        {
            Coordinator coordinator = _unitOfWork.Coordinator.Get(x => x.Id == coordinatorId);
            return View(coordinator);
        }

        public IActionResult Details(int eventId)
        {
            Events events = _unitOfWork.Event.Get(u => u.Id == eventId);
            return View(events);
        }


        public IActionResult Minithon()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Community()
        {
            return View();
        }

        public IActionResult UpcomingEvent()
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
