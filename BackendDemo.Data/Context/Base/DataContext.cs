using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using BackendDemo.Core.Entities;

namespace BackendDemo.Data.Context.Base;

public class DataContext : DbContext, IDataContext
{
    public Guid InstanceId { get; }

    public DataContext() : base()
    {
        InstanceId = Guid.NewGuid();
    }

    public DataContext(DbContextOptions options) : base(options)
    {
        InstanceId = Guid.NewGuid();
    }

    public object GetEntries<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        return Entry(entity);
    }

    public virtual IDbContextTransaction CurrentTransaction { get { return Database.CurrentTransaction; } }

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();

    } 

    public override int SaveChanges()
    {
        //return SaveChanges(true);
        var result = SaveChangesAsync(true);
        return result.Result;
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
    {
        var result = base.SaveChanges(acceptAllChangesOnSuccess);
        return result;
    }


}

