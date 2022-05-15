using BackendDemo.Business.Base;
using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Business.Services;

public class UserService : BaseService<User,UserDTO>,IUserService
{
    public UserService(IServiceProvider sp):base(sp)
    {
    }

    public async Task<User?> GetUserByFirstNameAndLastName(string firstName, string lastName)
    {
        return await UnitOfWork.Repository<User>().Query().AsNoTracking().FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
    }
}
