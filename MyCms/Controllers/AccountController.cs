using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;

namespace MyCms.Controllers
{
    public class AccountController : Controller
    {
        private ILoginRepository loginRepository;
        MyCmsContext db = new MyCmsContext();
        public AccountController()
        {
            loginRepository = new LoginRepository(db); 
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if(ModelState.IsValid)
            {
                if (loginRepository.IsExsitUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName","UserName was not found!");
                }
            }
           
            return View(login);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}