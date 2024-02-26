using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
using ResponseFramework;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeProductController : Controller
    {
        private readonly IProductService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto> _productService;
    
        #region [Ctor]
        public OfficeProductController(IProductService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto> productService)
        {
            _productService = productService;
        }
        #endregion

        #region [Guard(PostProductAppDto model)]
        private static JsonResult Guard(PostProductAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            return model.UnitPrice.Equals(null) ? new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField))
                 : new JsonResult(null);
        } 
        #endregion
        // is it okey
        #region [ Guard(PutProductAppDto model)]
        private static JsonResult Guard(PutProductAppDto model)
        {
            if (string.IsNullOrEmpty(model.Title)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            return model.UnitPrice.Equals(null) ? new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField))
                 : new JsonResult(null);
        } 
        #endregion
        

        #region [Post(PostProductAppDto model)]
        [HttpPost(Name = "PostProduct")]
        public async Task<IActionResult> Post(PostProductAppDto model)
        {
            Guard(model);
            var postResult = await _productService.Post(model);
            return new JsonResult(postResult);
        } 
        #endregion
        #region [Put(PutProductAppDto model)]
        [HttpPut(Name = "PutProduct")]
        public async Task<IActionResult> Put(PutProductAppDto model)
        {
            Guard(model);
            var putResult = await _productService.Put(model);
            return new JsonResult(putResult);
        } 
        #endregion
        #region [Delete(DeleteProductAppDto model)]
        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductAppDto model)
        {
            if (model.Id.Equals(null)) return new JsonResult(new Response<object>(PublicTools.Resources.MessageResource.Error_MandatoryField));
            var deleteResult = await _productService.Delete(model);
            return new JsonResult(deleteResult);
        } 
        #endregion
        #region [GetAll()]
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetAll()
        {
            var getAllResult = await _productService.GetAll();
            return new JsonResult(getAllResult);
        } 
        #endregion
    }
}
