using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos
{
    public class PutOrderResultAppDto
    {
        public List<PutOrderHeaderWithOrderDetailAppDto> Orders { get; set; }
    }
}
