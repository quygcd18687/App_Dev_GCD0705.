using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace TMS.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationDbContext _context;

        public TrainerController()
        {
            _context = new ApplicationDbContext();

        }



        // GET: Trainer
        public ActionResult Index()
        {
            return View(_context.Users.OfType<Trainer>().ToList());
        }


        // View Profile
        public ActionResult ViewProfile(string id)
        {

            var trainerInDb = _context.Users

                .OfType<Trainer>()
                .SingleOrDefault(t => t.Id == id);

            if (trainerInDb == null) return HttpNotFound();
            return View(trainerInDb);
        }






        //Update Profile

        [HttpGet]

        public ActionResult Edit(string id)
        {


            var trainerInDb = _context.Users.OfType<Trainer>()
                .SingleOrDefault(t => t.Id == id);

            if (trainerInDb == null) return HttpNotFound();

            return View(trainerInDb);
        }

        [HttpPost]


        public ActionResult Edit(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var InforUserInDb = _context.Users.OfType<Trainer>()
                .SingleOrDefault(t => t.Id == trainer.Id);

            if (InforUserInDb == null) return HttpNotFound();

            var trainerInDb = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == trainer.Id);

            trainerInDb.FullName = trainer.FullName;
            trainerInDb.BirthOfDate = trainer.BirthOfDate;
            trainerInDb.Address = trainer.Address;
            trainerInDb.PhoneNumber = trainer.PhoneNumber;
            trainerInDb.WorkingPlace = trainer.WorkingPlace;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //View Courses
        public ActionResult ViewCourse()
        {
            return View();
        }
    }
}