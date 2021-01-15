using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.Base
{
    public class BaseRepository<TEntity,TDto> : IBaseRepository<TEntity> where TEntity : class, new() where TDto : class,new()
    {
        private readonly IFreeSql _freeSql;

        public BaseRepository(IFreeSql freeSql)
        {
            this._freeSql = freeSql;
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> Insert(TEntity model)
        {
            return (int)await _freeSql.Insert(model).ExecuteIdentityAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task<int> Insert(List<TEntity> listEntity)
        {
            return await _freeSql.Insert(listEntity).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> InsertOrUpdate(TEntity model)
        {
            return await _freeSql.InsertOrUpdate<TEntity>()
                .SetSource(model) //需要操作的数据
                    //.IfExistsDoNothing() //如果数据存在，啥事也不干（相当于只有不存在数据时才插入）
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 根据ID删数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            return Convert.ToBoolean(await _freeSql.Delete<TEntity>().Where("Id = @Id", new { Id = id }).ExecuteAffrowsAsync());
        }

        /// <summary>
        /// 根据ID批量删数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            var count = await _freeSql.Delete<TEntity>(ids).ExecuteAffrowsAsync();
            return count > 0;
        }

        /// <summary>
        /// 根据表达式查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await _freeSql.Select<TEntity>()
                        .Where(whereExpression)
                        .ToListAsync();
        }

        /// <summary>
        /// 根据表达式查询并排序
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await _freeSql.Select<TEntity>()
                        .Where(whereExpression)
                        .OrderBy(strOrderByFileds)
                        .ToListAsync();
        }

        /// <summary>
        /// 根据表达式查询并排序和分页
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds, int page, int count)
        {
            return await _freeSql.Select<TEntity>()
                        .Where(whereExpression)
                        .OrderBy(strOrderByFileds)
                        .Page(page,count)
                        .ToListAsync();
        }

        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public async Task<TEntity> QueryById(object id)
        {
            return await _freeSql.Select<TEntity>().Where("Id = @Id", new { Id = id }).ToOneAsync();

        }
        /// <summary>
        /// 根据ID列表查询
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await _freeSql.Select<TEntity>(lstIds).ToListAsync();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity model)
        {
            var count = await _freeSql.Update<TEntity>()
                    .SetSourceIgnore(model, col => col == null)
                    .ExecuteAffrowsAsync();
            return count > 0;
        }
    }
}
