using OnlineShop.Application.Dtos;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Contracts.IService
{
    public interface IService<PostAppDto, PutAppDto, DeleteAppDto, GetAllAppDto>
    {
        Task<IResponse<object>> Post(PostAppDto postProductAppDto);
        Task<IResponse<object>> Put(PutAppDto PutProductAppDto);
        Task<IResponse<object>> Delete(DeleteAppDto DeleteProductAppDto);
        Task<IResponse<List<GetAllAppDto>>> GetAll();
    }
}
