using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
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
    public class ProductCategoryService : IProductCategoryService
    {
        #region [Private State]
        private readonly IRepository<ProductCategory, int> _repository;
        #endregion

        #region [Ctor]
        public ProductCategoryService(IRepository<ProductCategory, int> repository)
        {
            _repository = repository;
        }
        #endregion
        #region [Post]
        public async Task<IResponse<object>> Post(PostProductCategoryAppDto model)
        {
            #region [Validating Request]
            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]
            var productCategory = new ProductCategory
            {
                Title = model.Title,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated

            };

            var postResult = await _repository.InsertAsync(productCategory);
            if (!postResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            #endregion

            #region [Returning]

            return new Response<object>(new PostProductCategoryResultAppDto()
            {
                Title = model.Title,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

            #endregion

        }
        #endregion
        #region [Put]
        public async Task<IResponse<object>> Put(PutProductCategoryAppDto model)
        {
            #region [Validating Request]
            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]
            var PutResultId = await _repository.SelectByIdAsync(model.Id);
            if (PutResultId != null)
            {
                var productCategory = new ProductCategory
                {
                    Id = model.Id,
                    Title = model.Title,
                    Code = model.Code,
                    EntityDescription = model.EntityDescription,
                    IsActivated = model.IsActivated

                };
                var PutResult = await _repository.UpdateAsync(productCategory);
                if (!PutResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            }
            #endregion
            #region [Returning]

            return new Response<object>(new PutProductCategoryResultAppDto()
            {
                Id = model.Id,
                Title = model.Title,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,
         
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);


            #endregion

        }
        #endregion
        #region [Delete]
        public async Task<IResponse<object>> Delete(DeleteProductCategoryAppDto model)
        {
            #region [Task]
            var deleteResult = await _repository.DeleteAsync(model.Id);
            if (!deleteResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            #endregion

            #region [Returning]

            return new Response<object>(new DeleteProductCategoryResultAppDto()
            {
                Id = model.Id
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

            #endregion
        }
        #endregion
        #region [GetAll]
        public async Task<IResponse<List<GetAllProductCategoryAppDto>>> GetAll()
        {
            #region [Task]

            var getAllResult = await _repository.SelectAllAsync();
            if (!getAllResult.IsSuccessful) return new Response<List<GetAllProductCategoryAppDto>>(MessageResource.Error_FailProcess);

            #endregion

            #region [Returning]
            if (getAllResult.Result == null) return new Response<List<GetAllProductCategoryAppDto>>(MessageResource.Error_FailProcess);
            var Response = getAllResult.Result.Select(item => new GetAllProductCategoryAppDto()
            {
                Title = item.Title,
                Code = item.Code,
                EntityDescription = item.EntityDescription,
                IsActivated = item.IsActivated
            })
            .ToList();
            return new Response<List<GetAllProductCategoryAppDto>>(Response, true, PublicTools.Resources.MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
            #endregion
        }
        #endregion
    }
}
