using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class MaintenanceHistoryService : BaseService<MaintenanceHistory, MaintenanceHistoryDTO>, IMaintenanceHistoryService
{
    public MaintenanceHistoryService(IServiceProvider sp) : base(sp)
    {

    }
}
