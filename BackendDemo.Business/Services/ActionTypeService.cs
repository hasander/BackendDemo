using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class ActionTypeService : BaseService<ActionType, ActionTypeDTO>, IActionTypeService
{
    public ActionTypeService(IServiceProvider sp) : base(sp)
    {

    }
}
