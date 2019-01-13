using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using MusicStore.Repository;
using MusicStore.Entity;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Request.Cookies["UserData"] != null)
            {
                return RedirectToAction("Menu", "Store");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel login)
        {
            UserRepository repository = new UserRepository();
            User user = repository.GetUser(login.Username, login.Password);

            if (user != null)
            {
                Response.Cookies["UserData"]["Username"] = login.Username;
                Response.Cookies["UserData"]["Password"] = login.Password;
                Response.Cookies["UserData"].Expires = DateTime.Now.AddHours(1);
                return RedirectToAction("Menu", "Store");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is not exist");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel user)
        {
            ActionResult result = View();
            if (string.IsNullOrEmpty(user.Username))
            {
                ModelState.AddModelError("login.Username", "the Username is required");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("login.Password", "the Password is required");
            }
            if (user.Password != user.RepeatPassword)
            {
                ModelState.AddModelError("RepeatPassword", "the Passwords must be identical");
            }
            if (ModelState.IsValid)
            {
                result = View("ConfirmData", user);
            }
            return result;
        }

        public ActionResult ConfirmData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmData(UserModel userModel)
        {
            UserRepository repository = new UserRepository();
            userModel.Active = 1;
            userModel.LastUpdate = DateTime.Now.ToString("yyyy-MM-dd");
            User user = new User();
            user.customer.FirstName = userModel.FirstName;
            user.customer.LastName = userModel.LastName;
            user.customer.Company = userModel.Company;
            user.customer.Country = userModel.Country;
            user.customer.State = userModel.State;
            user.customer.City = userModel.City;
            user.customer.Address = userModel.Address;
            user.customer.PostalCode = userModel.PostalCode;
            user.customer.Phone = userModel.Phone;
            user.customer.Fax = userModel.Fax;
            user.customer.Email = userModel.Email;
            user.login.Username = userModel.Username;
            user.login.Password = userModel.Password;
            user.login.Active = userModel.Active;
            user.login.LastUpdate = userModel.LastUpdate;
            try
            {
                repository.InsertUser(user);
            }
            catch (Exception e)
            {
                Exception x = e;
                ModelState.AddModelError("", "email or username already exist inside our database");
                return View("SignUp", userModel);
            }
            return View("Index");
        }
    }
}