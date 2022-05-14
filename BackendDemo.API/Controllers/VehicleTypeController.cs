using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehicleTypeController : Controller
{
    IVehicleTypeService vehicleTypeService;
    public VehicleTypeController(IVehicleTypeService _vehicleTypeService)
    {
        vehicleTypeService = _vehicleTypeService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(VehicleTypeDTO vehicleType)
    {
        return await vehicleTypeService.Add(vehicleType);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await vehicleTypeService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await vehicleTypeService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(VehicleTypeDTO vehicleType)
    {
        return await vehicleTypeService.Update(vehicleType);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await vehicleTypeService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await vehicleTypeService.GetAll();
    }
}
