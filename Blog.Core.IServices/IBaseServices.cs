using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Contracts
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        Task<TEntity> QueryById(object id);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds, int page, int count);
        Task<List<TEntity>> QueryByIDs(object[] lstIds);
        Task<int> Insert(TEntity model);
        Task<int> Insert(List<TEntity> listEntity);
        Task<int> InsertOrUpdate(TEntity model);
        Task<bool> DeleteById(object id);
        Task<bool> DeleteByIds(object[] ids);
        Task<bool> Update(TEntity model);
    }
}
