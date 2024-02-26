using OnlineShop.Application.Dtos;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Contracts.IService
{
    public interface IService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto>
    {
        Task<IResponse<object>> Post(PostProductAppDto postProductAppDto);
        Task<IResponse<object>> Put(PutProductAppDto PutProductAppDto);
        Task<IResponse<object>> Delete(DeleteProductAppDto DeleteProductAppDto);
        Task<IResponse<List<GetAllProductAppDto>>> GetAll();
    }
}
