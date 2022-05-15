using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ActionTypeController : Controller
{
    IActionTypeService actionTypeService;
    public ActionTypeController(IActionTypeService _actionTypeService)
    {
        actionTypeService = _actionTypeService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(ActionTypeDTO actionType)
    {
        return await actionTypeService.Add(actionType);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await actionTypeService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await actionTypeService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(ActionTypeDTO actionType)
    {
        return await actionTypeService.Update(actionType);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await actionTypeService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await actionTypeService.GetAll();
    }
}
