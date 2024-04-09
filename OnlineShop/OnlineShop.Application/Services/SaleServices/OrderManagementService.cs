using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.Contracts.IService;
using OnlineShop.Domain.Aggregates.SaleAggregates;
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
    public class OrderManagementService: IOrderManagementService
    {

        #region [Private State]
        private readonly IRepository<OrderHeader,Guid> _orderHeaderRepository;
        private readonly IRepository<OrderDetail,Guid> _orderDetailRepository;
        #endregion
        #region [Ctor]
        public OrderManagementService(IRepository<OrderHeader, Guid> orderHeaderRepository, IRepository<OrderDetail, Guid> orderDetailRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        #region [Delete]
        public async Task<IResponse<object>> Delete(DeleteOrderManagementAppDto model)
        {
            #region [Task]
            var getResult = await _orderDetailRepository.DeleteAsync(model.Id);
            if (!getResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            #endregion

            #region [Returning]

            return new Response<object>(new DeleteOrderManagementAppDto()
            {
                Id = model.Id
            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

            #endregion
        }
        #endregion

        public Task<IResponse<List<GetAllOrderDetailAppDto>>> GetAll()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region [Post]
        public async Task<IResponse<object>> Post(PostOrderManagementAppDto model)
        {
            #region [Validating Request]
            //if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]

            foreach (var headerModel in model.OrderHeaders )
            {
                var orderHeader = new OrderHeader()
                {
                    Id = headerModel.Id,
                    Code = headerModel.Code,
                    Title = headerModel.Title,
                    EntityDescription = headerModel.EntityDescription,
                    IsActivated = headerModel.IsActivated,
                    DateCreatedLatin = headerModel.DateCreatedLatin,
                    DateCreatedPersian = headerModel.DateCreatedPersian,
                    IsModified = headerModel.IsModified,
                    DateModifiedLatin = headerModel.DateModifiedLatin,
                    DateModifiedPersian = headerModel.DateModifiedPersian,
                    IsDeleted = headerModel.IsDeleted,
                    DateSoftDeletedLatin = headerModel.DateSoftDeletedLatin,
                    DateSoftDeletedPersian = headerModel.DateSoftDeletedPersian,

                };

                var postOrderHeaderResult = await _orderHeaderRepository.InsertAsync(orderHeader);
                if (!postOrderHeaderResult.IsSuccessful)
                {
                    return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                }

                foreach (var detailModel in model.OrderDetails)
                {
                    if (detailModel.OrderHeaderId == orderHeader.Id)
                    {
                        var orderDetail = new OrderDetail
                        {
                            Id = detailModel.Id,
                            Code = detailModel.Code,
                            Title = detailModel.Title,
                            EntityDescription = detailModel.EntityDescription,
                            IsActivated = detailModel.IsActivated,
                            DateCreatedLatin = detailModel.DateCreatedLatin,
                            DateCreatedPersian = detailModel.DateCreatedPersian,
                            IsModified = detailModel.IsModified,
                            DateModifiedLatin = detailModel.DateModifiedLatin,
                            DateModifiedPersian = detailModel.DateModifiedPersian,
                            IsDeleted = detailModel.IsDeleted,
                            DateSoftDeletedLatin = detailModel.DateSoftDeletedLatin,
                            DateSoftDeletedPersian = detailModel.DateSoftDeletedPersian,
                            UnitPrice = detailModel.UnitPrice,
                            OrderHeaderId = detailModel.OrderHeaderId,
                        };
                        var postOrderDetailResult = await _orderDetailRepository.InsertAsync(orderDetail);
                        if (!postOrderDetailResult.IsSuccessful)
                        {
                            return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        }
                    }
                }
            }


            #endregion

            //#region [Returning]

            //return new Response<object>(new PostProductCategoryResultAppDto()
            //{5v
            //    ParentCategoryId = model.ParentCategoryId,
            //    ProductId = model.ProductId,
            //    Title = model.Title,
            //    Code = model.Code,
            //    EntityDescription = model.EntityDescription,
            //    IsActivated = model.IsActivated
            //}, true,
            //MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);

            //#endregion
            return new Response<object>("Orders successfully processed");

        }


        #region [Put]
        public async Task<IResponse<object>> Put(PutOrderManagementAppDto model)
        {
            #region [Validating Request]
            //if (model.Title == string.Empty) return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
            #endregion

            #region [Task]

            var orderDetail = new OrderDetail
            {
                Id = model.Id,
                Code = model.Code,
                Title = model.Title,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,
                IsModified = model.IsModified,
                IsDeleted = model.IsDeleted,
                UnitPrice = model.UnitPrice,
                OrderHeaderId = model.OrderHeaderId,

            };

        //            public Guid Id { get; set; }
        //public long Code { get; set; }
        //public string Title { get; set; }
        //public string? EntityDescription { get; set; }
        //public bool IsActivated { get; set; }
        //public DateTime DateCreatedLatin { get; set; }
        //public string? DateCreatedPersian { get; set; }
        //public bool IsModified { get; set; }
        //public DateTime DateModifiedLatin { get; set; }
        //public string? DateModifiedPersian { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime DateSoftDeletedLatin { get; set; }
        //public string? DateSoftDeletedPersian { get; set; }
        //public double UnitPrice { get; set; }
        //public Guid OrderHeaderId { get; set; }

        var PutResult = await _repository.UpdateAsync(productCategory);
            if (!PutResult.IsSuccessful) return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            #endregion
            #region [Returning]

            return new Response<object>(new PutProductCategoryResultAppDto()
            {
                Id = model.Id,
                ParentCategoryId = model.ParentCategoryId,
                ProductId = model.ProductId,
                Title = model.Title,
                Code = model.Code,
                EntityDescription = model.EntityDescription,
                IsActivated = model.IsActivated,

            }, true,
            MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);


            #endregion

        }
        #endregion



        #endregion

    }
}
