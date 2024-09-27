using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Text.Json;
using TinyProjectBusiness.Abstract;
using TinyProjectModels.Data_Transfer_Objects;
using TinyProjectModels.Entities;

namespace TinyProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int productId, Product updatedProduct)
        {
            try
            {
                await _productService.UpdateProductAsync(productId, updatedProduct);
            }
            catch (DataException dataException)
            {
                var messageData = JsonSerializer.Serialize(new ErrorDto(TinyProjectModels.Enums.StatusCode.NotFound, dataException.Message, dataException.StackTrace ?? string.Empty, dataException.InnerException?.Message ?? string.Empty));
                return BadRequest(messageData);
            }
            catch (Exception exception)
            {
                return BadRequest(JsonSerializer.Serialize(new ErrorDto(TinyProjectModels.Enums.StatusCode.BadRequest, exception.Message, exception.StackTrace ?? string.Empty, exception.InnerException?.Message ?? string.Empty)));
            }

            return Ok("Product updated successfully.");
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _productService.DeleteProductAsync(productId);
            }
            catch (DataException dataException)
            {
                var messageData = JsonSerializer.Serialize(new ErrorDto(TinyProjectModels.Enums.StatusCode.NotFound, dataException.Message, dataException.StackTrace ?? string.Empty, dataException.InnerException?.Message ?? string.Empty));
                return BadRequest(messageData);
            }
            catch (Exception exception)
            {
                return BadRequest(JsonSerializer.Serialize(new ErrorDto(TinyProjectModels.Enums.StatusCode.BadRequest, exception.Message, exception.StackTrace ?? string.Empty, exception.InnerException?.Message ?? string.Empty)));
            }

            return Ok("Product updated successfully.");
        }
    }
}
