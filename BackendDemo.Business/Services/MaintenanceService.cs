using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Business.IServices;

public class MaintenanceService : BaseService<Maintenance, MaintenanceDTO>, IMaintenanceService
{
    public MaintenanceService(IServiceProvider sp) : base(sp)
    {
    }

    public async Task<AppResponse<ICollection<MaintenanceDTO>>> MaintenanceReport(MaintenanceReportFilterDTO filterDTO)
    {
        var maintences = UnitOfWork.Repository<Maintenance>().Query()
            .Include(m => m.MaintenanceHistories)
            .ThenInclude(m => m.ActionType)
            .Include(m => m.Status)
            .Include(m => m.Vehicle)
            .ThenInclude(v => v.VehicleType)
            .Where(x=>filterDTO.EndDate>x.CreatedDate)
            .Where(x=>filterDTO.StartDate<x.CreatedDate)
            .ToList();
        return new AppResponse<ICollection<MaintenanceDTO>>()
        {
            Data = Mapper.Map<List<Maintenance>, List<MaintenanceDTO>>(maintences),
            Status = ResponseStatus.SUCCESS
        };
    }
}
