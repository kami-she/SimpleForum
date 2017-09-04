using AutoMapper;
using Data;
using ForumWebApplication.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ForumWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private IMapper mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.GetUser(mapper.Map<User>(model)))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User doesn't exists");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(mapper.Map<User>(model));
                if (userService.GetUser(mapper.Map<User>(model)))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}