using MeetingRoomApp.Models;
using MeetingRoomApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MeetingRoomApp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public MeetingController()
        {
            _context = new ApplicationDbContext(); 
        }

        public ActionResult Create()
        {
            var viewModel = new MeetingFormViewModel()
            {
                Categories = _context.Category.ToList()
            };
            return View(viewModel);
        }
    }
}