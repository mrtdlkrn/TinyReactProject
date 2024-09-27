using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TinyProjectDataAccess.Abstract;
using TinyProjectHelper;

namespace TinyProjectDataAccess.Concrete
{
    /// <summary>
    /// BaseAccess
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class BaseAccess<T> : IBaseAccess<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        /// <summary>
        /// BaseAccess
        /// </summary>
        /// <param name="context">context</param>
        public BaseAccess(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// IsEmpty
        /// </summary>
        /// <returns>Have database any data?</returns>
        public async Task<bool> IsEmpty()
        {
            return !await _dbSet.AnyAsync();
        }

        /// <summary>
        /// GetValueCountAsync
        /// </summary>
        /// <returns>Data count</returns>
        public async Task<int> GetValueCountAsync()
        {
            if (await IsEmpty())
            {
                return 0;
            }

            return await _dbSet.CountAsync();
        }

        /// <summary>
        /// GetValuesAsync
        /// </summary>
        /// <returns>List of DbSet Data</returns>
        /// <exception cref="DataException"></exception>
        public async Task<List<T>> GetValuesAsync()
        {
            if (await IsEmpty())
            {
                throw new DataException(CommonMessageHelper.DbSetDataIsEmpty(typeof(T).Name));
            }

            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// GetPaginingValuesAsync
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page data size</param>
        /// <returns>List of DbSet for pagining</returns>
        /// <exception cref="DataException"></exception>
        public async Task<List<T>> GetPaginingValuesAsync(int pageNumber, int pageSize)
        {
            if (await IsEmpty())
            {
                throw new DataException(CommonMessageHelper.DbSetDataIsEmpty(typeof(T).Name));
            }

            var skipIndex = (pageNumber-1) * pageSize;

            return await _dbSet.Skip(skipIndex).Take(pageSize).ToListAsync();
        }

        /// <summary>
        /// GetValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <returns>Value by Id</returns>
        public async Task<T> GetValueByIdAsync(int id)
        {
            if (await IsEmpty())
            {
                throw new DataException(CommonMessageHelper.DbSetDataIsEmpty(typeof(T).Name));
            }

            return await _dbSet.FindAsync(id) ?? throw new DataException(CommonMessageHelper.DbSetDataIsNull(typeof(T).Name, id));
        }

        /// <summary>
        /// DeleteValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <returns>Is success question's answer.</returns>
        /// <exception cref="DataException"></exception>
        public async Task<bool> DeleteValueByIdAsync(int id)
        {
            var value = await _dbSet.FindAsync(id) ?? throw new DataException(CommonMessageHelper.DbSetDataIsNull(typeof(T).Name, id));

            _dbSet.Remove(value);

            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// UpdateValueAsyncById
        /// </summary>
        /// <param name="id">Value Id</param>
        /// <param name="updatedValue">Value object</param>
        /// <returns>Is success question's answer.</returns>
        /// <exception cref="DataException"></exception>
        public async Task<bool> UpdateValueByIdAsync(int id, T updatedValue)
        {
            var value = await _dbSet.FindAsync(id) ?? throw new DataException(CommonMessageHelper.DbSetDataIsNull(typeof(T).Name, id));

            _mapper.Map(updatedValue, value);

            _dbSet.Update(value);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
