using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.Contracts.IService;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories.SaleRepositories;
using PublicTools.Resources;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleServices
{
    public class ProductService : IProductService
    {

        #region [Private State]
        private readonly IProductRepository _repository;
        private readonly IOrderRepository _orderRepository;
        #endregion
        #region [Ctor]
        public ProductService(IProductRepository repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }
        #endregion

        #region [Post]
        public async Task<IResponse<object>> Post(PostProductAppDto model)
        {
            #region [Validating Request]
            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            if (model.UnitPrice.Equals(null)) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            if (model.Code.Equals(null)) return new Response<object>(MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                UnitPrice = model.UnitPrice,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,
                IsModified = model.IsModified,
                // IsDeleted = model.IsDeleted
            };

            var postResult = await _repository.InsertAsync(product);
            if (!postResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            #endregion

            #region [Returning]

            return new Response<object>(new PostProductResultAppDto()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                UnitPrice = model.UnitPrice,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,
                IsModified = model.IsModified,
                //IsDeleted = model.IsDeleted
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

            #endregion

        }
        #endregion
        #region [Delete]
        public async Task<IResponse<object>> Delete(DeleteProductAppDto model)
        {
            #region [Task]
            var product = await _repository.GetProductById(model.Id, true);
            if (product == null || product.Result.IsDeleted)
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            var isProductUsedInOrderDetails = await _orderRepository.IsProductUsedInOrderDetails(model.Id);
            if (isProductUsedInOrderDetails)
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);


            product.Result.IsDeleted = true;
            var updateResult = await _repository.UpdateAsync(product.Result);
            if (!updateResult.IsSuccessful)
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            #endregion

            #region [Returning]
            return new Response<object>(new DeleteProductResultAppDto
            {
                Id = model.Id
            }, true, MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
            #endregion
        }
        #endregion
        //kh vs
        #region [GetAll]
        public async Task<IResponse<List<GetAllProductAppDto>>> GetAll()
        {
            #region [Task]

            var getAllResult = await _repository.GetAllProducts(false);
            if (!getAllResult.IsSuccessful) return new Response<List<GetAllProductAppDto>>(MessageResource.Error_FailProcess);

            #endregion

            #region [Returning]
            if (getAllResult.Result == null) return new Response<List<GetAllProductAppDto>>(MessageResource.Error_FailProcess);
            var Response = getAllResult.Result.Select(item => new GetAllProductAppDto()
            {
                Id = item.Id,
                Title = item.Title,
                UnitPrice = item.UnitPrice,
                Code = item.Code,
                EntityDescription = item.EntityDescription,
                IsActivated = item.IsActivated,
                IsModified = item.IsModified,
                IsDeleted = item.IsDeleted
            })
            .ToList();
            return new Response<List<GetAllProductAppDto>>(Response, true, PublicTools.Resources.MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
            #endregion
        }
        #endregion
        #region [Put]
        public async Task<IResponse<object>> Put(PutProductAppDto model)
        {
            #region [Validating Request]
            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            if (model.UnitPrice.Equals(null)) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            if (model.Code.Equals(null)) return new Response<object>(MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]
            var product = await _repository.GetProductById(model.Id, false);
            if (!product.IsSuccessful || product.Result == null)
            {
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            }

          
            product.Result.Title = model.Title;
            product.Result.UnitPrice = model.UnitPrice;
            product.Result.Code = model.Code;
            product.Result.EntityDescription = model.EntityDescription;
            product.Result.IsActivated = model.IsActivated;
            product.Result.IsModified = model.IsModified;
            // IsDeleted = model.IsDeleted,

            var PutResult = await _repository.UpdateAsync(product.Result);
            if (!PutResult.IsSuccessful)
            {
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            }
            #endregion

            #region [Returning]

            return new Response<object>(new PutProductResultAppDto()
            {
                Id = model.Id,
                Title = model.Title,
                UnitPrice = model.UnitPrice,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,
                IsModified = model.IsModified,
                //IsDeleted = model.IsDeleted
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
            #endregion
        }
        #endregion

    }

}














