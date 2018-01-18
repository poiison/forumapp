using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.business.irepositoy
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Busca a partir de um ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindById(int id);

        /// <summary>
        /// Listar objetos
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> FindAll();

        /// <summary>
        /// Inserir um objeto
        /// </summary>
        /// <param name="item"></param>
        Task<TEntity> Insert(TEntity entidade);

        /// <summary>
        /// Excluir um objeto
        /// </summary>
        /// <param name="item"></param>
        Task<int> Delete(int entidadeId);

        /// <summary>
        /// Alterar um objeto
        /// </summary>
        /// <param name="item"></param>
        Task<TEntity> Update(TEntity entidade, int key);

        /// <summary>
        /// Lista os objetos na base baseado em uma expressão exemplo: c => c.ativo == true
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> FindAllbyExpression(Expression<Func<TEntity, bool>> predicate);
    }
}
