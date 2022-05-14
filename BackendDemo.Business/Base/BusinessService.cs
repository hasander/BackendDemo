using AutoMapper;
using BackendDemo.SharedLibrary.DTOs;
using BackendDemo.Core.Entities;
using BackendDemo.Data.Base;
using BackendDemo.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration; 

namespace BackendDemo.Business.Base;

public abstract class BusinessService : IBusinessService
{
    #region Fields

    private IUnitOfWork _unitOfWork;
    private UnitOfWorkType _serviceType;

    private IMapper _mapper { get; set; }
    private IConfiguration _configuration { get; set; }
    private IServiceProvider _serviceProvider { get; set; }
    private IHttpContextAccessor _contextAccessor { get; set; }
    public User _user { get; set; }

    #endregion Fields

    #region Props

    public IUnitOfWork UnitOfWork { get => _unitOfWork; }
    public IMapper Mapper { get => _mapper; }
    public IConfiguration Configuration { get => _configuration; }
    public IServiceProvider ServiceProvider { get => _serviceProvider; }
    public User User { get => _user ?? CurrentUser().Result; }

    public IHttpContextAccessor contextAccessor { get => _contextAccessor; }

    protected readonly AppResponse AppResponse = new AppResponse();

    public async Task<User> CurrentUser()
    {
        if (_contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
        {
            return await UnitOfWork.Repository<User>().GetByIdAsync(Convert.ToInt64(_contextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault().Value));
        }
        return null;
    }

    protected IUnitOfWork BaseUnitOfWork()
    {
        switch (_serviceType)
        {
            case UnitOfWorkType.BackendDemoApp:
                return UnitOfWork;
            default:
                return null;
        }
    }

    #endregion Props

    public BusinessService(IServiceProvider serviceProvider, UnitOfWorkType serviceType = UnitOfWorkType.Tanimsiz)
    {
        _serviceType = serviceType;
        _serviceProvider = serviceProvider;
        _configuration = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
        _mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
        _unitOfWork = (IUnitOfWork<AppDbContext>)serviceProvider.GetService(typeof(IUnitOfWork<AppDbContext>));

        _contextAccessor = (IHttpContextAccessor)serviceProvider.GetService(typeof(IHttpContextAccessor));

        _unitOfWork.User = User;

    }
}

public enum UnitOfWorkType
{
    BackendDemoApp = 1,
    Kimlik = 2,
    Tanimsiz = 3,
}
