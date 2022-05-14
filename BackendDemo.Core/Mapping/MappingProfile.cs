using AutoMapper;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ActionType, ActionTypeDTO>();
        CreateMap<ActionTypeDTO, ActionType>();

        CreateMap<BaseEntity, BaseDTO>();
        CreateMap<BaseDTO, BaseEntity>();

        CreateMap<Maintenance, MaintenanceDTO>();
        CreateMap<MaintenanceDTO, Maintenance>();

        CreateMap<MaintenanceHistory, MaintenanceHistoryDTO>();
        CreateMap<MaintenanceHistoryDTO, MaintenanceHistory>();

        CreateMap<PictureGroup, PictureGroupDTO>();
        CreateMap<PictureGroupDTO, PictureGroup>();

        CreateMap<Status, StatusDTO>();
        CreateMap<StatusDTO, Status>();
         
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();

        CreateMap<Vehicle, VehicleDTO>();
        CreateMap<VehicleDTO, Vehicle>();

        CreateMap<VehicleType, VehicleTypeDTO>();
        CreateMap<VehicleTypeDTO, VehicleType>();
    }
}
