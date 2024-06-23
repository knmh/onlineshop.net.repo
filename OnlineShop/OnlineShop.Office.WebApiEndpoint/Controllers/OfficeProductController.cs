using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using PublicTools.Resources;
using ResponseFramework;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Authorize]
    [Route("api/OfficeProduct")]
    [ApiController]
    public class OfficeProductController : ControllerBase
    {
        #region [Private State] 
        private readonly IProductService _productService;
        private readonly AccountService _accountService;
        #endregion

        #region [Ctor]
        public OfficeProductController(IProductService productService, AccountService accountService)
        {
            _productService = productService;
            _accountService= accountService;
        }
        #endregion

        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostProductAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title) || model.Title.Length > 100)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.UnitPrice.Equals(null))
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.Code == null || model.Code == 0 || model.Code.ToString().Length > 50)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.EntityDescription != null && model.EntityDescription.Length > 1000)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MaxLengthField));

            return new JsonResult(null);
        }
        #endregion
        // is it okey
        #region [ Guard(PutProductAppDto model)]
        private static JsonResult Guard(PutProductAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title) || model.Title.Length > 100)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.UnitPrice.Equals(null))
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.Code == null || model.Code == 0 || model.Code.ToString().Length > 50)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.EntityDescription != null && model.EntityDescription.Length > 1000)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MaxLengthField));

            return new JsonResult(null);
        }
        #endregion


        #region [Post(PostProductAppDto model)]
        [HttpPost(Name = "PostProduct")]
        public async Task<IActionResult> Post(PostProductAppDto model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_NoAuthorization));
            }
            if (!await _accountService.IsTokenValidAsync(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_InvalidToken));
            }
            Guard(model);
            var postResult = await _productService.Post(model);
            return new JsonResult(postResult);
        }
        #endregion
        #region [Put(PutProductAppDto model)]
        [HttpPut(Name = "PutProduct")]
        public async Task<IActionResult> Put(PutProductAppDto model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_NoAuthorization));
            }
            if (!await _accountService.IsTokenValidAsync(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_InvalidToken));
            }
            Guard(model);
            var putResult = await _productService.Put(model);
            return new JsonResult(putResult);
        }
        #endregion
        #region [Delete(DeleteProductAppDto model)]
        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductAppDto model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_NoAuthorization));
            }
            if (!await _accountService.IsTokenValidAsync(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_InvalidToken));
            }
            if (model.Id.Equals(null)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            var deleteResult = await _productService.Delete(model);
            return new JsonResult(deleteResult);
        }
        #endregion
        #region [GetAll()]
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetAll()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_NoAuthorization));
            }
            if (!await _accountService.IsTokenValidAsync(token))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_InvalidToken));
            }
            var getAllResult = await _productService.GetAll();
            return new JsonResult(getAllResult);
        }
        #endregion
    }
}
