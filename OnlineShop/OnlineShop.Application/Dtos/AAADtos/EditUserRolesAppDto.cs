using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.AAADtos
{
    public class EditUserRolesAppDto
    {

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string CellPhone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public List<string> Roles { get; set; }

      
        [Required]
        public List<string> RoleId { get; set; }
      
    }
}

