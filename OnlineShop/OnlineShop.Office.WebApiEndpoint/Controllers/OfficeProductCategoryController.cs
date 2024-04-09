using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using ResponseFramework;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [Route("api/OfficeProductCategory")]
    [ApiController]
    public class OfficeProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        #region [Ctor]
        public OfficeProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        #endregion
        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostProductCategoryAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            }
            else
            {

                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Info_SuccessfullProcess));
            }
        }
        #endregion

        // is it okey
        #region [ Guard(PutProductAppDto model)]
        private static JsonResult Guard(PutProductCategoryAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            }
            else
            {

                return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Info_SuccessfullProcess));
            }
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