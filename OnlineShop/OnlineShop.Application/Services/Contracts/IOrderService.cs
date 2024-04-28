using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Contracts
{
    public interface IOrderService : IService<PostOrderAppDto,PutOrderAppDto,DeleteOrderAppDto,GetAllOrderAppDto>
        //IService<PostOrderDetailAppDto, PutOrderDetailAppDto, DeleteOrderDetailAppDtosAppDto, GetAllOrderDetailAppDto>,
        //IService<PostOrderHeaderAppDto, PutOrderHeaderAppDto, DeleteOrderHeaderAppDto, GetAllOrderHeaderAppDto>
    {

    }

}
