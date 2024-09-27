namespace TinyProjectDataAccess.Abstract
{
    /// <summary>
    /// IBaseAccess
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IBaseAccess<T> where T : class
    {
        /// <summary>
        /// IsEmpty
        /// </summary>
        /// <returns>bool isEmpty</returns>
        Task<bool> IsEmpty();

        /// <summary>
        /// GetValueCountAsync
        /// </summary>
        /// <returns>Data count</returns>
        Task<int> GetValueCountAsync();

        /// <summary>
        /// GetValuesAsync
        /// </summary>
        /// <returns>List of DbSet</returns>
        Task<List<T>> GetValuesAsync();

        /// <summary>
        /// GetPaginingValuesAsync
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page data size</param>
        /// <returns>List of DbSet for pagining</returns>
        Task<List<T>> GetPaginingValuesAsync(int pageNumber, int pageSize);

        /// <summary>
        /// GetValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <returns>Value by Id</returns>
        Task<T> GetValueByIdAsync(int id);

        /// <summary>
        /// DeleteValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <returns>Is success question's answer.</returns>
        Task<bool> DeleteValueByIdAsync(int id);

        /// <summary>
        /// UpdateValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <param name="updatedValue">Value object</param>
        /// <returns>Is success question's answer.</returns>
        Task<bool> UpdateValueByIdAsync(int id, T updatedValue);
    }
}
