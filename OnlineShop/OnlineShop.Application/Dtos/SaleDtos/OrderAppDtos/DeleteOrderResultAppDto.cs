using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos
{
    public class DeleteOrderResultAppDto
    {
        public Guid OrderHeaderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
