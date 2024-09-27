using TinyProjectBusiness.Abstract;
using TinyProjectDataAccess.Abstract;
using TinyProjectModels.Entities;

namespace TinyProjectBusiness.Concrete
{
    /// <summary>
    /// ProductService
    /// </summary>
    /// <param name="baseAccess">base access</param>
    public class ProductService(IBaseAccess<Product> baseAccess) : IProductService
    {
        private readonly IBaseAccess<Product> _baseAccess = baseAccess;

        /// <summary>
        /// GetProductCountAsync
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetProductCountAsync()
        {
            return await _baseAccess.GetValueCountAsync();
        }

        /// <summary>
        /// GetProductsAsync
        /// </summary>
        /// <returns>List of product</returns>
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _baseAccess.GetValuesAsync();
        }

        /// <summary>
        /// GetProductsAsyncForPagining
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List of product for pagining</returns>
        public async Task<List<Product>> GetProductsAsyncForPagining(int pageNumber, int pageSize)
        {
            return await _baseAccess.GetPaginingValuesAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// GetProductsAsyncForPagining
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product with Id</returns>
        public async Task<Product> GetProductsByIdAsync(int productId)
        {
            return await _baseAccess.GetValueByIdAsync(productId);
        }

        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Is success question's answer</returns>
        public async Task<bool> DeleteProductAsync(int productId)
        {
            return await _baseAccess.DeleteValueByIdAsync(productId);
        }

        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Is success question's answer</returns>
        public async Task<bool> UpdateProductAsync(int productId, Product updatedProduct)
        {
            return await _baseAccess.UpdateValueByIdAsync(productId, updatedProduct);
        }
    }
}
