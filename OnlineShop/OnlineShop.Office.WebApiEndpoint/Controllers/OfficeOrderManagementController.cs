using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderDetailAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;
using System.Collections.Generic;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/OfficeOrderManagement")]
    [ApiController]
    public class OfficeOrderManagementController : ControllerBase
    {
        private readonly IOrderManagementService _OrderManagementService;

        #region [Ctor]
        public OfficeOrderManagementController(IOrderManagementService orderManagementService)
        {
            _OrderManagementService = orderManagementService;
        }
        #endregion

        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostOrderManagementAppDto model)
        {
            foreach (var orderDetail in model.OrderDetails)
            {
                if (string.IsNullOrEmpty(orderDetail.Title) || orderDetail.UnitPrice == null)
                {
                    return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
                }
            }

            foreach (var orderHeader in model.OrderHeaders)
            {
                if (string.IsNullOrEmpty(orderHeader.Title))
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


        #region [PostOrderManagement(PostOrderManagementAppDto model)]
        public async Task<IActionResult> PostOrderManagement(PostOrderManagementAppDto model)
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
    }
}
