//using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
//using OnlineShop.Application.Services.Contracts;
//using OnlineShop.Application.Services.Contracts.IService;
//using OnlineShop.Domain.Aggregates.SaleAggregates;
//using OnlineShop.Domain.Frameworks.Abstracts;
//using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
//using PublicTools.Resources;
//using ResponseFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace OnlineShop.Application.Services.SaleServices
//{
//    public class ProductService: IProductService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto>
//    {
//        #region [Private State]
//        private readonly IRepository<Product, Guid> _repository; 
//        #endregion

//        #region [Ctor]
//        public ProductService(IRepository<Product, Guid> repository)
//        {
//            _repository = repository;
//        } 
//        #endregion

//        #region [Post]
//        public async Task<IResponse<object>> Post(PostProductAppDto model)
//        {
//            #region [Validating Request]
//            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
//            if (model.UnitPrice.Equals(null)) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
//            #endregion

//            #region [Task]
//            var product = new Product
//            {
//                Title = model.Title,
//                UnitPrice = model.UnitPrice
//            };

//            var postResult = await _repository.InsertAsync(product);
//            if (!postResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

//            #endregion

//            #region [Returning]

//            return new Response<object>(new PostProductResultAppDto()
//            {
//                Title = model.Title,
//                UnitPrice = model.UnitPrice
//            }, true,
//            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

//            #endregion

//        }
//        #endregion

//        #region [Put]
//        public async Task<IResponse<object>> Put(PutProductAppDto model)
//        {
//            #region [Validating Request]
//            if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
//            if (model.UnitPrice.Equals(null)) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
//            #endregion

//            #region [Task]
//            var PutResultId = await _repository.SelectByIdAsync(model.Id);
//            if (PutResultId != null)
//            {
//                var product = new Product
//                {
//                    Title = model.Title,
//                    UnitPrice = model.UnitPrice
//                };
//                var PutResult = await _repository.UpdateAsync(product);
//                if (!PutResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
//            }
//            #endregion


//            #region [Returning]

//            return new Response<object>(new PutProductResultAppDto()
//            {
//                Title = model.Title,
//                UnitPrice = model.UnitPrice
//            }, true,
//            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);


//            #endregion

//        }
//        #endregion
//        //kh vs
//        #region [Delete]
//        public async Task<IResponse<object>> Delete(DeleteProductAppDto model)
//        {
//            #region [Task]
//            var deleteResult = await _repository.DeleteAsync(model.Id);
//            if (!deleteResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

//            #endregion
            
//            #region [Returning]

//            return new Response<object>(new DeleteProductResultAppDto()
//            {
//                Id = model.Id
//            }, true,
//            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

//            #endregion
//        }
//        #endregion
//        //kh vs
//        #region [GetAll]
//        public async Task<IResponse<List<GetAllProductAppDto>>> GetAll()
//        {
//            #region [Task]

//            var getAllResult = await _repository.SelectAllAsync();
//            if (!getAllResult.IsSuccessful) return new Response<List<GetAllProductAppDto>>(MessageResource.Error_FailProcess);

//            #endregion

//            #region [Returning]
//            if (getAllResult == null) return new Response<List<GetAllProductAppDto>>(MessageResource.Error_FailProcess);
//            var Response = getAllResult.Result.Select(item => new GetAllProductAppDto()
//            {
//                Id = item.Id,
//                Title = item.Title,
//                UnitPrice = item.UnitPrice
//            })
//            .ToList();
//            return new Response<List<GetAllProductAppDto>>(Response, true, PublicTools.Resources.MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
//            #endregion
//        } 
//        #endregion

//    }


//}














