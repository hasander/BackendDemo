using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BackendDemo.Data.Context.Base;

public interface IDataContext : IDisposable
{
    int SaveChanges();

    int SaveChanges(bool acceptAllChangesOnSuccess); 

    IDbContextTransaction CurrentTransaction { get; }

    IDbContextTransaction BeginTransaction();

}
