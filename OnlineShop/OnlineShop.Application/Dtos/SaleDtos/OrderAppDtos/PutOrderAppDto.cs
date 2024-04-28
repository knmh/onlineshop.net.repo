using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos
{
    public class PutOrderAppDto
    {
        public List<PutOrderHeaderWithOrderDetailAppDto> Orders { get; set; }
    }
}
