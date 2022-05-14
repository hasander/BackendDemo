using BackendDemo.Core.Entities;
using BackendDemo.Data.Context.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

namespace BackendDemo.Data.Base;

public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DataContext
{
    private TContext _dbContext;
    private IDbContextTransaction _transaction;
    private bool _disposed;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public Dictionary<Type, object> Repositories
    {
        get { return _repositories; }
        set { Repositories = value; }
    }

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepository<T> Repository<T>() where T : BaseEntity
    {
        if (Repositories.Keys.Contains(typeof(T)))
        {
            return Repositories[typeof(T)] as IRepository<T>;
        }

        IRepository<T> repo = new Repository<T>(_dbContext, this);
        Repositories.Add(typeof(T), repo);
        return repo;
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
     

    #region Unit of Work Transactions

    public virtual IDbContextTransaction CurrentTransaction
    {
        get
        {
            return _dbContext.CurrentTransaction;
        }
    }

    public User User { get; set; }

    public IDbContextTransaction BeginTransaction()
    {
        _transaction = _dbContext.BeginTransaction();
        return _transaction;
    }

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }
    public void Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }

    public bool CommitTransaction()
    {
        _transaction.Commit();
        return true;
    }

    public void RollbackTransaction()
    {
        _transaction.Rollback();
    }

    #endregion

    #region Dispose
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        _disposed = true;
    }

    #endregion
}
