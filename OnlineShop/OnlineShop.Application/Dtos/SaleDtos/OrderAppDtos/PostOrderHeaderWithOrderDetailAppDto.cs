using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos
{
    public class PostOrderHeaderWithOrderDetailAppDto
    {
        public PostOrderHeaderAppDto OrderHeader { get; set; }
        public List<PostOrderDetailAppDto> OrderDetails { get; set; }
    }
}
