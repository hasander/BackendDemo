using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class MaintenanceService : BaseService<Maintenance, MaintenanceDTO>, IMaintenanceService
{
    public MaintenanceService(IServiceProvider sp) : base(sp)
    {
    }
}
