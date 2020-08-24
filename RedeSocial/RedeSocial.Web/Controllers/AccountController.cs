using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Services.Account;
using RedeSocial.Web.ViewModel.Account;
using Microsoft.AspNet.Identity;



namespace RedeSocial.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }

        public AccountController(IAccountService accountService, IAccountIdentityManager accountIdentityManager)
        {
            this.AccountService = accountService;
            this.AccountIdentityManager = accountIdentityManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            
            try
            {
                var result = await this.AccountIdentityManager.Login(model.UserName, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
                    return View(model);
                }

                if (!String.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return Redirect("/");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(model);
            }
            
        }







    }
}
