using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.AAADtos
{
    public class DeleteUserAppDto
    {
     

        [Required]
        public string UserId { get; set; }


        [Required]
        public List<string> RoleId { get; set; }
    }
}
