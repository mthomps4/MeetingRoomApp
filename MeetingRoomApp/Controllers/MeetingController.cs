using MeetingRoomApp.Models;
using MeetingRoomApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetingFormViewModel()
            {
                Categories = _context.Category.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Category.ToList();
                return View("Create", viewModel);
            }

            //var userId = User.Identity.GetUserId(); 
            //var user = _context.Users.Single(u => u.Id == userId);
            //var selectedCat = _context.Category.Single(c => c.Id == viewModel.Category); 
            //Migrated through controller 

            var meeting = new Meeting
            {
                leadById = User.Identity.GetUserId(), 
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category, 
                Venue = viewModel.Venue
            };

            _context.Metting.Add(meeting);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}