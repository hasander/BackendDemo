using BackendDemo.Core.Entities;
using BackendDemo.Data.Context.Base;
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
}
