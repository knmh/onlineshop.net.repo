using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos;
using OnlineShop.Application.Services.Contracts;
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
        //#region [Guard(PostProductAppDto model)]
        //private static JsonResult Guard(PostProductCategoryAppDto model)
        //{
        //    if (string.IsNullOrEmpty(model.Title)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
         
        //}
        //#endregion
        //// is it okey
        //#region [ Guard(PutProductAppDto model)]
        //private static JsonResult Guard(PutProductAppDto model)
        //{
        //    if (string.IsNullOrEmpty(model.Title)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
        //    return model.UnitPrice.Equals(null) ? new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField))
        //         : new JsonResult(null);
        //}
        //#endregion


    }
}