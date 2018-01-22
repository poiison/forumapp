using forumapp.business.ibusiness;
using forumapp.business.irepositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.services
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository"></param>
        public BusinessBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Busca a partir de um ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> FindById(int id)
        {
            try
            {
                return _repository.FindById(id);
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Listar objetos
        /// </summary>
        /// <returns></returns>
        public virtual Task<ICollection<TEntity>> FindAll()
        {
            try
            {
                return _repository.FindAll();
            }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Inserir um objeto
        /// </summary>
        /// <param name="item"></param>
        public Task<TEntity> Insert(TEntity entidade)
        {
            try
            {
                return _repository.Insert(entidade);
            }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Excluir um objeto
        /// </summary>
        /// <param name="item"></param>
        public Task<int> Delete(int entidadeId)
        {
            try
            {
                return _repository.Delete(entidadeId);
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Alterar um objeto
        /// </summary>
        /// <param name="item"></param>
        public Task<TEntity> Update(TEntity entidade, int key)
        {
            try
            {
                return _repository.Update(entidade, key);
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Lista os objetos na base baseado em uma expressão exemplo: c => c.ativo == true
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<TEntity>> FindAllbyExpression(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _repository.FindAllbyExpression(predicate);
            }
            catch (Exception) { throw; }
        }
    }
}
