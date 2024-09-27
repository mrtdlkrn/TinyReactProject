using TinyProjectModels.Entities;

namespace TinyProjectBusiness.Abstract
{
    public interface IProductService
    {
        /// <summary>
        /// GetProductCountAsync
        /// </summary>
        /// <returns></returns>
        Task<int> GetProductCountAsync();

        /// <summary>
        /// GetProductsAsync
        /// </summary>
        /// <returns>List of product</returns>
        Task<List<Product>> GetProductsAsync();

        /// <summary>
        /// GetProductsAsyncForPagining
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List of product for pagining</returns>
        Task<List<Product>> GetProductsAsyncForPagining(int pageNumber, int pageSize);

        /// <summary>
        /// GetProductsAsyncForPagining
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product with Id</returns>
        Task<Product> GetProductsByIdAsync(int productId);

        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Is success question's answer</returns>
        Task<bool> DeleteProductAsync(int productId);

        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Is success question's answer</returns>
        Task<bool> UpdateProductAsync(int productId, Product updatedProduct);
    }
}
