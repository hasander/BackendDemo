namespace BackendDemo.Business.Base
{
    using AutoMapper;
    using BackendDemo.Data.Base;
    using Microsoft.Extensions.Configuration;
    using System;

    public interface IBusinessService
    {
        IUnitOfWork UnitOfWork { get; }

        IMapper Mapper { get; }

        IConfiguration Configuration { get; }

        IServiceProvider ServiceProvider { get; }
    }
}
