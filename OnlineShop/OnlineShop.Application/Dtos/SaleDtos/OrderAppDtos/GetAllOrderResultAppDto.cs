using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos
{
    public class GetAllOrderResultAppDto
    {
        public List<GetAllOrderHeaderWithOrderDetailResultAppDto> Orders { get; set; }
    }
}
