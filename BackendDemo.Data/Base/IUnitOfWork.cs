using BackendDemo.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BackendDemo.Data.Base;

public interface IUnitOfWork<TContext> : IUnitOfWork
{
}

public interface IUnitOfWork : IDisposable
{
    public User User { get; set; }

    IRepository<T> Repository<T>() where T : BaseEntity;

    Task<int> Commit();

    int SaveChanges();

    void Rollback();

    bool CommitTransaction();

    void RollbackTransaction();



    IDbContextTransaction CurrentTransaction { get; }

    IDbContextTransaction BeginTransaction();

    void Dispose(bool disposing);
}
