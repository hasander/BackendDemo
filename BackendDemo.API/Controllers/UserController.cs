using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpPut("Add")]
    public async Task<AppResponse> Add(UserDTO user)
    {
        return await userService.Add(user);
    }
    [HttpDelete("SoftDelete")]
    public async Task<AppResponse> SoftDelete([FromBody] int id)
    {
        return await userService.DeleteSoftById(id);
    }

    [HttpDelete("HardDelete")]
    public async Task<AppResponse> HardDelete([FromBody] int id)
    {
        return await userService.DeleteById(id);
    }
    [HttpPost("Update")]
    public async Task<AppResponse> Update(UserDTO user)
    {
        return await userService.Update(user);
    }

    [HttpGet("GetByID")]
    public async Task<AppResponse> GetByID([FromBody] int id)
    {
        return await userService.GetById(id);
    }

    [HttpGet("GetAll")]
    public async Task<AppResponse> GetAll()
    {
        return await userService.GetAll();
    }
}
