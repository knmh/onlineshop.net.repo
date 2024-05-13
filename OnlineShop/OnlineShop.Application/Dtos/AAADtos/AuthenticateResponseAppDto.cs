using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.AAADtos
{
    public class AuthenticateResponseAppDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
