using forumapp.business.irepositoy;
using forumapp.repository.context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.repository.repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DataContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public RepositoryBase()
        {
            _context = new DataContext();
        }

        /// <summary>
        /// Find by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<TEntity> FindById(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// List All
        /// </summary>
        /// <returns></returns>
        public async virtual Task<ICollection<TEntity>> FindAll()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="item"></param>
        public async virtual Task<TEntity> Insert(TEntity item)
        {
            try
            {
                _context.Set<TEntity>().Add(item);
                await _context.SaveChangesAsync();

                return item;

            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item"></param>
        public async virtual Task<int> Delete(int id)
        {
            try
            {
                var existe = await _context.Set<TEntity>().FindAsync(id);

                if (existe != null)
                {
                    _context.Set<TEntity>().Remove(existe);
                    return await _context.SaveChangesAsync();
                }

                return 0;

            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        public async virtual Task<TEntity> Update(TEntity item, int key)
        {
            try
            {
                if (item == null)
                    return null;

                TEntity existe = await _context.Set<TEntity>().FindAsync(key);

                if (existe != null)
                {
                    _context.Entry(existe).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                }

                return existe;
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Find by Expression
        /// </summary>
        /// <returns></returns>
        public async virtual Task<ICollection<TEntity>> FindAllbyExpression(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _context.Set<TEntity>().Where(predicate).ToListAsync();
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
