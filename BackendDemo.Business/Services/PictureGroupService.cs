using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class PictureGroupService : BaseService<PictureGroup, PictureGroupDTO>, IPictureGroupService
{
    public PictureGroupService(IServiceProvider sp) : base(sp)
    {
    }
}
