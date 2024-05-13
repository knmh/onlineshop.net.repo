using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;
using System.Collections.Generic;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/OfficeOrderManagement")]
    [ApiController]
    public class OfficeOrderController : ControllerBase
    {
        private readonly IOrderService _OrderManagementService;

        #region [Ctor]
        public OfficeOrderController(IOrderService orderManagementService)
        {
            _OrderManagementService = orderManagementService;
        }
        #endregion

        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostOrderAppDto model)
        {
            foreach (var order in model.Orders)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    if (string.IsNullOrEmpty(orderDetail.Title) || orderDetail.UnitPrice == null)
                    {
                        return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
                    }
                }

                if (string.IsNullOrEmpty(order.OrderHeader.Title))
                {
                    return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
                }
            }

            return new JsonResult(null);
        }
        #endregion
        // is it okey
        #region [ Guard(PutProductAppDto model)]
        //private static JsonResult Guard(PostOrderHeaderAppDto model)
        //{


        //}
        #endregion

        [HttpPost(Name = "PostOrderManagement")]
        #region [Post(PostOrderManagementAppDto model)]
        public async Task<IActionResult> Post(PostOrderAppDto model)
        {
            var validationResult = Guard(model);
            if (validationResult.Value != null)
            {
                return validationResult;
            }
            var postResult = await _OrderManagementService.Post(model);
            return new JsonResult(postResult);
        }
        #endregion

        #region [Put(PutOrderManagementAppDto model)]
        [HttpPut(Name = "PutOrderManagement")]
        public async Task<IActionResult> Put(PutOrderAppDto model)
        {
           // Guard(model);
            var putResult = await _OrderManagementService.Put(model);
            return new JsonResult(putResult);
        }
        #endregion
        #region [Delete(DeleteOrderManagementAppDto model)]
        [HttpDelete(Name = "DeleteOrderManagement")]
        public async Task<IActionResult> Delete(DeleteOrderAppDto model)
        {
            if (model.Equals(null)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            var deleteResult = await _OrderManagementService.Delete(model);
            return new JsonResult(deleteResult);
        }
        #endregion
        #region [GetAll()]
        [HttpGet(Name = "GetOrderManagement")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _OrderManagementService.GetAll();
            return new JsonResult(getAllResult);
        }
        #endregion

    }
}
