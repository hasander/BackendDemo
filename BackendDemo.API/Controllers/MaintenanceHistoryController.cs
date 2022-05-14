using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MaintenanceHistoryController : Controller
{
    IMaintenanceHistoryService maintenanceHistoryService;
    public MaintenanceHistoryController(IMaintenanceHistoryService _maintenanceHistoryService)
    {
        maintenanceHistoryService = _maintenanceHistoryService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(MaintenanceHistoryDTO maintenanceHistory)
    {
        return await maintenanceHistoryService.Add(maintenanceHistory);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await maintenanceHistoryService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await maintenanceHistoryService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(MaintenanceHistoryDTO maintenanceHistory)
    {
        return await maintenanceHistoryService.Update(maintenanceHistory);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await maintenanceHistoryService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await maintenanceHistoryService.GetAll();
    }
}
