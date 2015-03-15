using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly Guid _instanceId;

        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            _instanceId = Guid.NewGuid();
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public IRepository<T> Repository<T>() where T : class, new()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (IRepository<T>)_repositories[type];

            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));

            return (IRepository<T>)_repositories[type];
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            return _context.GetValidationErrors();
        }
    }
}
