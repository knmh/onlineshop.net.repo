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
        [Required]
        public string UserId { get; set; }
        [Required]

        public List<string> UserRoles { get; set; }
        [Required]
        public List<IdentityRole> Roles { get; set; }
    }
}

