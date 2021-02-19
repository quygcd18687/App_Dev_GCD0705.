using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class TraineeController : Controller
    {
        private ApplicationDbContext _context;

        public TraineeController()
        {
            _context = new ApplicationDbContext();

        }



        // GET: Trainee
        public ActionResult Index()
        {
            return View(_context.Users.OfType<Trainee>().ToList());
        }


        // View Profile
        public ActionResult ViewProfile(string id)
        {

            var traineeInDb = _context.Users
                .OfType<Trainee>()
                .SingleOrDefault(t => t.Id == id);

            if (traineeInDb == null) return HttpNotFound();
            return View(traineeInDb);
        }



        // View Assigned Course
        public ActionResult AssignedCourse()
        {
            return View();
        }


        // View Available Course
        public ActionResult AvailableCourse()
        {
            return View();
        }


        //Change Password
        public ActionResult ChangePasswors()
        {
            return View();
        }
    }
}