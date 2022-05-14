using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehicleController : Controller
{
    IVehicleService vehicleService;
    public VehicleController(IVehicleService _vehicleService)
    {
        vehicleService = _vehicleService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(VehicleDTO vehicle)
    {
        return await vehicleService.Add(vehicle);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await vehicleService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await vehicleService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(VehicleDTO vehicle)
    {
        return await vehicleService.Update(vehicle);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await vehicleService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await vehicleService.GetAll();
    }
}
