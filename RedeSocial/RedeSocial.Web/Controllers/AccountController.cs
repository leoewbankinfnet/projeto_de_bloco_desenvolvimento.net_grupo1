using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Domain.Account;
using RedeSocial.Service.Account;

namespace RedeSocial.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }

        public AccountController (IAccountService accountService, IAccountIdentityManager accountIdentityManager)
        {
            this.AccountService = accountService;
            this.AccountIdentityManager = AccountIdentityManager;
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
