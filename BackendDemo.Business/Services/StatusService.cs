using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class StatusService : BaseService<Status, StatusDTO>, IStatusService
{
    public StatusService(IServiceProvider sp) : base(sp)
    {
    }
}
