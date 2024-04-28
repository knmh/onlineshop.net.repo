using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.AAAServices
{
    public class AccountService
    {
        private readonly SignInManager<OnlineShopUser> _signInManager;
        public AccountService()
        {
                
        }

        //public IActionResult Login(string redirectUrl = "/")
        //{
        //    return View(new LoginModel
        //    {
        //        RedirectUrl = redirectUrl,
        //    });
        //}
    }
}
