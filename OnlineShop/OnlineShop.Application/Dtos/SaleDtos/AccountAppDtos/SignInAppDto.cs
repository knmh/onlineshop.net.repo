using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.AccountAppDtos
{
    public class SignInAppDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public string Password { get; set; }


    }
}
