using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.Helper;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private const string _usernameCookie = "kantilever_rememberusername";
        private IAgentBSKlantBeheer _agentBSKlantBeheer;

        public AuthenticationController()
        {
            _agentBSKlantBeheer = new AgentBSKlantBeheer();
        }

        public ActionResult Login(string returnUrl)
        {
            string username = string.Empty;
            var cookie = Request.Cookies[_usernameCookie];
            if (cookie != null)
            {
                username = cookie.Value;
            }

            var loginModel = new LoginModel() { Username = username, RememberMe = cookie != null, ReturnUrl = returnUrl };

            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var klant = _agentBSKlantBeheer.Login(login.Username, HashHelper.sha256_hash(login.Password));
            if (klant == null)
            {
                ModelState.AddModelError("login", "De combinatie van de gebruikersnaam en het wachtwoord incorrect");
                return View(login);
            }

            Request.Cookies.Remove(_usernameCookie);
            if (login.RememberMe)
            {
                SetUserNameCookie(login);
            }
            else
            {
                RemoveUserNameCookie();
            }
            FormsAuthentication.SetAuthCookie(login.Username, false);

            if (!string.IsNullOrWhiteSpace(login.ReturnUrl))
            {
                return Redirect(login.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Catalogus");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Catalogus");
        }

        private void RemoveUserNameCookie()
        {
            var usernameCookie = new HttpCookie(_usernameCookie) { Expires = DateTime.Now.AddDays(-1) };
            Response.Cookies.Add(usernameCookie);
        }

        private void SetUserNameCookie(LoginModel login)
        {
            var usernameCookie = new HttpCookie(_usernameCookie) { Value = login.Username, Expires = DateTime.Now.AddMonths(1) };
            Response.Cookies.Add(usernameCookie);
        }
    }
}