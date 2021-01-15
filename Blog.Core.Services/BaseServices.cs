using Blog.Core.Application.Contracts;
using Blog.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        public IBaseRepository<TEntity> BaseDal;
        public async Task<bool> DeleteById(object id)
        {
            return await BaseDal.DeleteById(id);
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await BaseDal.DeleteByIds(ids);
        }

        public async Task<int> Insert(TEntity model)
        {
            return await BaseDal.Insert(model);
        }

        public async Task<int> Insert(List<TEntity> listEntity)
        {
            return await BaseDal.Insert(listEntity);
        }

        public async Task<int> InsertOrUpdate(TEntity model)
        {
            return await BaseDal.InsertOrUpdate(model);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await BaseDal.Query(whereExpression);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await BaseDal.Query(whereExpression, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds, int page, int count)
        {
            return await BaseDal.Query(whereExpression, strOrderByFileds,page,count);
        }

        public async Task<TEntity> QueryById(object id)
        {
            return await BaseDal.QueryById(id);
        }

        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await BaseDal.QueryByIDs(lstIds);
        }

        public async Task<bool> Update(TEntity model)
        {
            return await BaseDal.Update(model);
        }
    }
}
