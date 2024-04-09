using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Contracts
{
    public interface IProductCategoryService : IService<PostProductCategoryAppDto, PutProductCategoryAppDto, DeleteProductCategoryAppDto, GetAllProductCategoryAppDto>
    {
    }
}
