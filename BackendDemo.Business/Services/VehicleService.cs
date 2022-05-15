using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public class VehicleService : BaseService<Vehicle, VehicleDTO>, IVehicleService
{
    public VehicleService(IServiceProvider sp) : base(sp)
    {
    }
}
