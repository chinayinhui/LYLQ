using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using LYLQ.WebUI.Filters;
using LYLQ.WebUI.Models;

namespace LYLQ.WebUI.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }
            
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

    }
}
