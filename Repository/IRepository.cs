using System;
using System.Linq;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(object id);
        void InsertGraph(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        IRepositoryQuery<TEntity> Query();
        Guid InstanceId { get; }
    }
}
