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
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineShop.Application.Services.SaleServices
{
    public class OrderService : IOrderService
    {

        #region [Private State] 
        private readonly IOrderRepository _orderRepository;
        #endregion  
        #region [Ctor]
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region [Put]
        public async Task<IResponse<object>> Put(PutOrderAppDto model)
        {
            #region [Validating Request]
            foreach (var headerModel in model.Orders)
            {
                if (string.IsNullOrEmpty(headerModel.OrderHeader.Title))
                {
                    return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
                }

                foreach (var detailModel in headerModel.OrderDetails)
                {
                    if (string.IsNullOrEmpty(detailModel.Title) || detailModel.UnitPrice == null)
                    {
                        return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
                    }
                }
            }
            #endregion
            #region [Task]
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var orderWithDetails in model.Orders)
                    {
                        var orderHeader = await _orderRepository.SelectByIdWithDetailsAsync(orderWithDetails.OrderHeader.Id);
                        if (!orderHeader.IsSuccessful)
                        {
                            return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        }
                        orderHeader.Result.Title = orderWithDetails.OrderHeader.Title;
                        orderHeader.Result.Code = orderWithDetails.OrderHeader.Code;
                        orderHeader.Result.EntityDescription = orderWithDetails.OrderHeader.EntityDescription;
                        orderHeader.Result.IsActivated = orderWithDetails.OrderHeader.IsActivated;
                        orderHeader.Result.DateCreatedLatin = orderWithDetails.OrderHeader.DateCreatedLatin;
                        orderHeader.Result.DateCreatedPersian = orderWithDetails.OrderHeader.DateCreatedPersian;
                        orderHeader.Result.IsModified = orderWithDetails.OrderHeader.IsModified;
                        orderHeader.Result.DateModifiedLatin = orderWithDetails.OrderHeader.DateModifiedLatin;
                        orderHeader.Result.DateModifiedPersian = orderWithDetails.OrderHeader.DateModifiedPersian;
                        orderHeader.Result.IsDeleted = orderWithDetails.OrderHeader.IsDeleted;
                        orderHeader.Result.DateSoftDeletedLatin = orderWithDetails.OrderHeader.DateSoftDeletedLatin;
                        orderHeader.Result.DateSoftDeletedPersian = orderWithDetails.OrderHeader.DateSoftDeletedPersian;
                        orderHeader.Result.SellerUserId = orderWithDetails.OrderHeader.SellerUserId;
                        orderHeader.Result.SellerRoleId = orderWithDetails.OrderHeader.SellerRoleId;
                        orderHeader.Result.BuyerUserId = orderWithDetails.OrderHeader.BuyerUserId;
                        orderHeader.Result.BuyerRoleId = orderWithDetails.OrderHeader.BuyerRoleId;



                        //var updateHeaderResult = await _orderRepository.UpdateAsync(orderHeader.Result);
                        //if (!updateHeaderResult.IsSuccessful)
                        //{
                        //    return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        //}
                        foreach (var detail in orderWithDetails.OrderDetails)
                        {
                            // Find the corresponding OrderDetail in the OrderHeader entity
                            var orderDetail = orderHeader.Result.OrderDetails.FirstOrDefault(d => d.ProductId == detail.ProductId && d.OrderHeaderId == orderWithDetails.OrderHeader.Id);
                            if (orderDetail != null)
                            {
                                orderDetail.Code = detail.Code;
                                orderDetail.Title = detail.Title;
                                orderDetail.EntityDescription = detail.EntityDescription;
                                orderDetail.IsActivated = detail.IsActivated;
                                orderDetail.DateCreatedLatin = detail.DateCreatedLatin;
                                orderDetail.DateCreatedPersian = detail.DateCreatedPersian;
                                orderDetail.IsModified = detail.IsModified;
                                orderDetail.DateModifiedLatin = detail.DateModifiedLatin;
                                orderDetail.DateModifiedPersian = detail.DateModifiedPersian;
                                orderDetail.IsDeleted = detail.IsDeleted;
                                orderDetail.DateSoftDeletedLatin = detail.DateSoftDeletedLatin;
                                orderDetail.DateSoftDeletedPersian = detail.DateSoftDeletedPersian;
                                orderDetail.UnitPrice = detail.UnitPrice;
                                //orderDetail.OrderHeaderId = detail.OrderHeaderId;
                                //orderDetail.ProductId = detail.ProductId;
                            }
                            else
                            {
                                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                            }
                        }
                        var updateHeaderResult = await _orderRepository.UpdateAsync(orderHeader.Result);
                        if (!updateHeaderResult.IsSuccessful)
                        {
                            return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        }
                        //orderWithDetails.OrderDetails.Add(orderDetail);
                        // var updateDetailResult = await _orderRepository.UpdateAsync(orderDetail);
                        //if (!updateDetailResult.IsSuccessful)
                        //{
                        //    return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        //}

                    }
                    scope.Complete();

                    #endregion
                    #region [Returning]
                    return new Response<object>(
                new { Orders = model.Orders },
                true,
                PublicTools.Resources.MessageResource.Info_SuccessfullProcess,
                string.Empty,
                HttpStatusCode.OK
            );
                }
            }
            catch (Exception)
            {
                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
            }
            #endregion

        }
        #endregion
        #region [GetAll]
        public async Task<IResponse<List<GetAllOrderAppDto>>> GetAll()
        {
            #region [Task]

            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var getAllOrderResult = await _orderRepository.SelectAllWithDetailsAsync(skip: 3, take: 2);

                    if (!getAllOrderResult.IsSuccessful)
                    {
                        return new Response<List<GetAllOrderAppDto>>(MessageResource.Error_FailProcess);
                    }

                    var orders = getAllOrderResult.Result.Select(header =>
                    {
                        var orderDetails = header.OrderDetails.Select(detail => new GetAllOrderDetailAppDto
                        {
                            Code = detail.Code,
                            Title = detail.Title,
                            EntityDescription = detail.EntityDescription,
                            IsActivated = detail.IsActivated,
                            DateCreatedLatin = detail.DateCreatedLatin,
                            DateCreatedPersian = detail.DateCreatedPersian,
                            IsModified = detail.IsModified,
                            DateModifiedLatin = detail.DateModifiedLatin,
                            DateModifiedPersian = detail.DateModifiedPersian,
                            IsDeleted = detail.IsDeleted,
                            DateSoftDeletedLatin = detail.DateSoftDeletedLatin,
                            DateSoftDeletedPersian = detail.DateSoftDeletedPersian,
                            UnitPrice = detail.UnitPrice,
                            ProductId = detail.ProductId
                        }).ToList();

                        return new GetAllOrderAppDto
                        {
                            Orders = new List<GetAllOrderHeaderWithOrderDetailAppDto>
                    {
                new GetAllOrderHeaderWithOrderDetailAppDto
                {
                    OrderHeaders = new List<GetAllOrderHeaderAppDto>
                    {
                        new GetAllOrderHeaderAppDto
                        {
                            Id = header.Id,
                            Code = header.Code,
                            Title = header.Title,
                            EntityDescription = header.EntityDescription,
                            IsActivated = header.IsActivated,
                            DateCreatedLatin = header.DateCreatedLatin,
                            DateCreatedPersian = header.DateCreatedPersian,
                            IsModified = header.IsModified,
                            DateModifiedLatin = header.DateModifiedLatin,
                            DateModifiedPersian = header.DateModifiedPersian,
                            IsDeleted = header.IsDeleted,
                            DateSoftDeletedLatin = header.DateSoftDeletedLatin,
                            DateSoftDeletedPersian = header.DateSoftDeletedPersian,
                            SellerUserId = header.SellerUserId,
                            SellerRoleId = header.SellerRoleId,
                            BuyerUserId = header.BuyerUserId,
                            BuyerRoleId = header.BuyerRoleId
                        }
                    },
                    OrderDetails = orderDetails
                }
                    }
                        };
                    }).ToList();
                    scope.Complete();


                    #endregion
                    #region [Returning]
                    return new Response<List<GetAllOrderAppDto>>(
                    orders,
                    true,
                    PublicTools.Resources.MessageResource.Info_SuccessfullProcess,
                    string.Empty,
                    HttpStatusCode.OK
            );
                }
            }
            catch (Exception)
            {

                return new Response<List<GetAllOrderAppDto>>(MessageResource.Error_FailProcess);

            }
            #endregion
        }
        #endregion
        #region [Delete]
        public async Task<IResponse<object>> Delete(DeleteOrderAppDto model)
        {
            #region [Task]

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {

                    var orderHeaderResult = await _orderRepository.SelectByIdWithDetailsAsync(model.OrderHeaderId);
                    if (!orderHeaderResult.IsSuccessful)
                    {
                        return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                    }

                    var orderHeader = orderHeaderResult.Result;
                    var orderDetails = orderHeader.OrderDetails;

                    var detailToDelete = orderDetails.FirstOrDefault(d => d.ProductId == model.ProductId);

                    if (detailToDelete != null)
                    {
                        orderDetails.Remove(detailToDelete);
                        await _orderRepository.SaveAsync();

                    }
                    else
                    {
                        return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                    }
                    var remainingDetails = orderDetails.Where(d => d.OrderHeaderId == model.OrderHeaderId).ToList();
                    if (remainingDetails.Count == 0)
                    {
                        var deleteHeaderResult = await _orderRepository.DeleteAsync(orderHeader);
                        if (!deleteHeaderResult.IsSuccessful)
                        {
                            return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        }
                    }
                    scope.Complete();
                    #region [Returning]
                    return new Response<object>(new DeleteOrderResultAppDto()
                    {
                        OrderHeaderId = model.OrderHeaderId,
                        ProductId = model.ProductId,
                    }, true,
                  MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
                    #endregion
                }

                catch (Exception ex)
                {
                    return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);


                }
            }
            #endregion
            #region [Returning]
            return new Response<object>(new DeleteOrderResultAppDto()
            {
                OrderHeaderId = model.OrderHeaderId,
                ProductId = model.ProductId,
            }, true,
          MessageResource.Info_SuccessfullProcess, string.Empty, HttpStatusCode.OK);
            #endregion
        }
        #endregion
        #region [Post]
        public async Task<IResponse<object>> Post(PostOrderAppDto model)
        {
            #region [Validating Request]
            foreach (var headerModel in model.Orders)
            {
                if (string.IsNullOrEmpty(headerModel.OrderHeader.Title))
                {
                    return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
                }

                foreach (var detailModel in headerModel.OrderDetails)
                {
                    if (string.IsNullOrEmpty(detailModel.Title) || detailModel.UnitPrice == null)
                    {
                        return new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField);
                    }
                }
            }
            #endregion

            #region [Task]

            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var headerModel in model.Orders)
                    {
                        var orderHeader = new OrderHeader()
                        {
                            Id = Guid.NewGuid(),
                            Code = headerModel.OrderHeader.Code,
                            Title = headerModel.OrderHeader.Title,
                            EntityDescription = headerModel.OrderHeader.EntityDescription,
                            IsActivated = headerModel.OrderHeader.IsActivated,
                            DateCreatedLatin = headerModel.OrderHeader.DateCreatedLatin,
                            DateCreatedPersian = headerModel.OrderHeader.DateCreatedPersian,
                            IsModified = headerModel.OrderHeader.IsModified,
                            DateModifiedLatin = headerModel.OrderHeader.DateModifiedLatin,
                            DateModifiedPersian = headerModel.OrderHeader.DateModifiedPersian,
                            IsDeleted = headerModel.OrderHeader.IsDeleted,
                            DateSoftDeletedLatin = headerModel.OrderHeader.DateSoftDeletedLatin,
                            DateSoftDeletedPersian = headerModel.OrderHeader.DateSoftDeletedPersian,
                            SellerUserId = headerModel.OrderHeader.SellerUserId,
                            SellerRoleId = headerModel.OrderHeader.SellerRoleId,
                            BuyerUserId = headerModel.OrderHeader.BuyerUserId,
                            BuyerRoleId = headerModel.OrderHeader.BuyerRoleId,
                        };

                        orderHeader.OrderDetails = new List<OrderDetail>();

                        foreach (var detailModel in headerModel.OrderDetails)
                        {
                            var orderDetail = new OrderDetail
                            {
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
                                ProductId = detailModel.ProductId,
                                //OrderHeaderId = orderHeader.Id,
                            };

                            orderHeader.OrderDetails.Add(orderDetail);
                        }

                        var postOrderHeaderResult = await _orderRepository.InsertAsync(orderHeader);
                        if (!postOrderHeaderResult.IsSuccessful)
                        {
                            return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);
                        }
                    }

                    scope.Complete();
                    #region [Returning]
                    return new Response<object>(
                        new { Orders = model.Orders },
                        true,
                        PublicTools.Resources.MessageResource.Info_SuccessfullProcess,
                        string.Empty,
                        HttpStatusCode.OK
                    );
                    // return new Response<object>("Orders successfully processed");
                    #endregion
                }
            }
            catch (Exception)
            {

                return new Response<object>(PublicTools.Resources.MessageResource.Error_FailProcess);

            }

        }
        #endregion
      
        #endregion
    
    }

}
 

