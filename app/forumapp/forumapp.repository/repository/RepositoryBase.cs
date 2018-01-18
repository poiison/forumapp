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
        /// Construtor da Classe
        /// </summary>
        public RepositoryBase()
        {
            _context = new DataContext();
        }

        /// <summary>
        /// Busca um objeto na base a partir de um Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindById(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Lista os objetos na base
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> FindAll()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Insere um objeto na base
        /// </summary>
        /// <param name="item"></param>
        public async Task<TEntity> Insert(TEntity item)
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
        /// Exclui um objeto da base
        /// </summary>
        /// <param name="item"></param>
        public async Task<int> Delete(int id)
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
        /// Altera um objeto da base
        /// </summary>
        /// <param name="item"></param>
        public async Task<TEntity> Update(TEntity item, int key)
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
        /// Lista os objetos na base baseado em uma expressão exemplo: c => c.ativo == true
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> FindAllbyExpression(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _context.Set<TEntity>().Where(predicate).ToListAsync();
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Liberar os recursos instanciados pela classe DbContext
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
