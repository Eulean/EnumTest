using EnumTest.Context;
using EnumTest.Models;
using EnumTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnumTest.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Register()
        {
            var genders = _context.Genders.ToList();

            var genderList = genders.Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            genderList.Insert(0, new SelectListItem
            {
                Text = "Select Gender ",
                Value = ""
            });

            var viewModel = new RegisterViewModel
            {
                Gender = genderList,
                User = new User()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register (RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(viewModel.User);
                _context.SaveChanges();

                return RedirectToAction("Index","Users");
            }

            return View("Register", viewModel);
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}