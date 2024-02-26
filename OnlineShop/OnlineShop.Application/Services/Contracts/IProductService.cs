using OnlineShop.Application.Dtos;
using OnlineShop.Application.Services.Contracts.IService;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Contracts
{
    public interface IProductService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto> : IService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto>
    {

    }
}
