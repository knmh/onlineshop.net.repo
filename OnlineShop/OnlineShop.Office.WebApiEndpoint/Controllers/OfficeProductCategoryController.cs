using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using ResponseFramework;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Authorize]
    [Route("api/OfficeProductCategory")]
    [ApiController]
    public class OfficeProductCategoryController : ControllerBase
    {
        #region [Private State] 
        private readonly IProductCategoryService _productCategoryService; 
        #endregion

        #region [Ctor]
        public OfficeProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        #endregion
        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostProductCategoryAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title) || model.Title.Length > 100)
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
        private static JsonResult Guard(PutProductCategoryAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title) || model.Title.Length > 100)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.Code == null || model.Code == 0 || model.Code.ToString().Length > 50)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));

            if (model.EntityDescription != null && model.EntityDescription.Length > 1000)
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MaxLengthField));

            return new JsonResult(null);
        }
        #endregion


        #region [Post(PostProductCategoryAppDto model)]
        [HttpPost(Name = "PostProductCategory")]
        public async Task<IActionResult> Post(PostProductCategoryAppDto model)
        {
            Guard(model);
            var postResult = await _productCategoryService.Post(model);
            return new JsonResult(postResult);
        }
        #endregion
        #region [Put(PutProductCategoryAppDto model)]
        [HttpPut(Name = "PutProductCategory")]
        public async Task<IActionResult> Put(PutProductCategoryAppDto model)
        {
            Guard(model);
            var putResult = await _productCategoryService.Put(model);
            return new JsonResult(putResult);
        }
        #endregion
        #region [Delete(DeleteProductCategoryAppDto model)]
        [HttpDelete(Name = "DeleteProductCategory")]
        public async Task<IActionResult> Delete(DeleteProductCategoryAppDto model)
        {
            if (model.Id.Equals(null)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            var deleteResult = await _productCategoryService.Delete(model);
            return new JsonResult(deleteResult);
        }
        #endregion
        #region [GetAll()]
        [HttpGet(Name = "GetProductCategory")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _productCategoryService.GetAll();
            return new JsonResult(getAllResult);
        }
        #endregion


    }
}