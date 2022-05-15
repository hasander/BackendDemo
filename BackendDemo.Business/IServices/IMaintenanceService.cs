using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;
using BackendDemo.SharedLibrary.DTOs;

namespace BackendDemo.Business.IServices;

public interface IMaintenanceService : IBaseService<Maintenance, MaintenanceDTO>
{
    Task<AppResponse<ICollection<MaintenanceDTO>>> MaintenanceReport(MaintenanceReportFilterDTO filterDTO);
}
