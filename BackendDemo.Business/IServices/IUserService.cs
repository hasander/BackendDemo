using BackendDemo.Business.Base;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;

namespace BackendDemo.Business.IServices;

public interface IUserService : IBaseService<User, UserDTO>
{
    Task<User?> GetUserByFirstNameAndLastName(string firstName, string lastName);
}
