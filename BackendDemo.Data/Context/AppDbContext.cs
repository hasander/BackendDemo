using BackendDemo.Core.Entities;
using BackendDemo.Data.Context.Base;
using BackendDemo.Data.Context.Seed;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Data.Context;

public class AppDbContext : DataContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> User { get; set; }
    public DbSet<Vehicle> Vehicle { get; set; }
    public DbSet<VehicleType> VehicleType { get; set; }
    public DbSet<Maintenance> Maintenance { get; set; }
    public DbSet<MaintenanceHistory> MaintenanceHistory { get; set; }
    public DbSet<PictureGroup> PictureGroup { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<ActionType> ActionType { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddUserSeed();

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}
