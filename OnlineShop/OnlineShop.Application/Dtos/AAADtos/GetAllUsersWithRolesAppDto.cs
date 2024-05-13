using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.AAADtos
{
    public class GetAllUsersWithRolesAppDto
    {
       
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string CellPhone { get; set; }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        
        public string NationalId { get; set; }
        
        public string UserId { get; set; }

       public List<string> Roles { get; set; }
    }
}
