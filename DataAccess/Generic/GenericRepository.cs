using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereExpression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        Task<bool> CreateAsync(T entity);
    }


    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        public GenericRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// Agrega un registro al modelo de datos<typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">class</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await unitOfWork.Context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return true;
        }

        /// <summary>
        /// Retorna una colección de registros<typeparamref name="T"/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync()
        {
            return await unitOfWork.Context.Set<T>().ToListAsync();
        }


        /// <summary>
        /// Retorna una colección de registros<typeparamref name="T"/> filtrada
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereExpression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = unitOfWork.Context.Set<T>();

            if (whereExpression != null )
            {
                query = query.Where(whereExpression);
            }

            foreach (string item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}
