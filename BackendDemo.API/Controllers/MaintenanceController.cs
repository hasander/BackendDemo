using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MaintenanceController : Controller
{
    IMaintenanceService maintenanceService;
    public MaintenanceController(IMaintenanceService _maintenanceService)
    {
        maintenanceService = _maintenanceService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(MaintenanceDTO maintenance)
    {
        return await maintenanceService.Add(maintenance);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await maintenanceService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await maintenanceService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(MaintenanceDTO maintenance)
    {
        return await maintenanceService.Update(maintenance);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await maintenanceService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await maintenanceService.GetAll();
    }

    [HttpGet("MaintenanceReport")]
    public async Task<AppResponse<ICollection<MaintenanceDTO>>> MaintenanceReport(MaintenanceReportFilterDTO filterDTO)
    {
        return await maintenanceService.MaintenanceReport(filterDTO);
    }
}
