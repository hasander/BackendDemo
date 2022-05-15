using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PictureGroupController : Controller
{
    IPictureGroupService pictureGroupService;
    public PictureGroupController(IPictureGroupService _pictureGroupService)
    {
        pictureGroupService = _pictureGroupService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(PictureGroupDTO pictureGroup)
    {
        return await pictureGroupService.Add(pictureGroup);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await pictureGroupService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await pictureGroupService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(PictureGroupDTO pictureGroup)
    {
        return await pictureGroupService.Update(pictureGroup);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await pictureGroupService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await pictureGroupService.GetAll();
    }
}
