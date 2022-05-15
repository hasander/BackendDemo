using BackendDemo.Business.IServices;
using BackendDemo.Core.DTOs;
using BackendDemo.SharedLibrary.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BackendDemo.UnitTests;

public class ActionTypeTests
{
    IUserService userService;

    public ActionTypeTests()
    {
        var userList = new List<UserDTO>
            {
                new UserDTO {ID=1,FirstName="User1",LastName="User1LastName" },
                new UserDTO {ID=2,FirstName="User2",LastName="User2LastName" },
                new UserDTO {ID=3,FirstName="User3",LastName="User3LastName" }
            };
        Mock<IUserService> userServiceMoq = new Mock<IUserService>();
        userServiceMoq.Setup(mr => mr.GetAll()).ReturnsAsync(new AppResponse() { Data = userList, Status = ResponseStatus.SUCCESS, Message = "" });


        userServiceMoq.Setup(mr => mr.GetById(It.IsAny<int>())).ReturnsAsync((int i) => new AppResponse()
        {
            Data = userList.FirstOrDefault(x => x.ID == i),
            Status = userList.FirstOrDefault(x => x.ID == i) != null ? ResponseStatus.SUCCESS : ResponseStatus.ERROR
        });


        userServiceMoq.Setup(mr => mr.Add(It.IsAny<UserDTO>())).Callback(
            (UserDTO target) =>
            {
                if (!string.IsNullOrEmpty(target.FirstName) && !string.IsNullOrEmpty(target.LastName))
                    userList.Add(target);
            });
        userServiceMoq.Setup(mr => mr.Update(It.IsAny<UserDTO>())).Callback(
            (UserDTO target) =>
            {
                var original = userList.Where(q => q.ID == target.ID).Single();

                if (original == null)
                {
                    throw new InvalidOperationException();
                }

                original.FirstName = target.FirstName;
                original.LastName = target.LastName;

            });
         userService = userServiceMoq.Object;

    }
    [Fact]
    public async Task Add()
    {
        await userService.Add(new UserDTO() { FirstName = "Hasan", LastName = "DER" });
        var list = await userService.GetAll();
        Assert.Equal(((List<UserDTO>)list.Data).Count , 4);
    }

    [Fact]
    public async Task GetAll()
    {
        var list = await userService.GetAll();
        Assert.True(((List<UserDTO>)list.Data).Count==3 );
    }

    [Fact]
    public async Task Update()
    {
        await userService.Update(new UserDTO() { ID=1,FirstName="Backend",LastName = "Demo"});
        var user = await userService.GetById(1);
        Assert.True(((UserDTO)user.Data).FirstName== "Backend");
    }
}
