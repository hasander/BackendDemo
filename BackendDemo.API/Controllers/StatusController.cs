using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StatusController : Controller
{
    IStatusService statusService;
    public StatusController(IStatusService _statusService)
    {
        statusService = _statusService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(StatusDTO status)
    {
        return await statusService.Add(status);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await statusService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await statusService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(StatusDTO status)
    {
        return await statusService.Update(status);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await statusService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await statusService.GetAll();
    }
}
