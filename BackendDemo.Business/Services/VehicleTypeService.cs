using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class VehicleTypeService : BaseService<VehicleType, VehicleTypeDTO>, IVehicleTypeService
{
    public VehicleTypeService(IServiceProvider sp) : base(sp)
    {
    }
}
