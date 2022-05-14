using BackendDemo.SharedLibrary.DTOs;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendDemo.Business.Base;

public partial class BaseService<TEntity, TDto> : BusinessService, IBaseService<TEntity, TDto>
    where TEntity : BaseEntity
    where TDto : BaseDTO
{
    public BaseService(IServiceProvider serviceProvider, UnitOfWorkType serviceType = UnitOfWorkType.Cit) : base(serviceProvider, serviceType)
    {
    }

    public virtual async Task<AppResponse> Add(TDto dto)
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().AddAsync(Mapper.Map<TEntity>(dto));
        AppResponse.Message = "Kayit Ekleme Basarili";
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    }

    public virtual async Task<AppResponse> Update(TDto dto)
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().UpdateAsync(Mapper.Map<TEntity>(dto));
        AppResponse.Message = "Kayit Guncelleme Basarili";
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    }

    public virtual long Count()
    {
        return BaseUnitOfWork().Repository<TEntity>().Query().Count();
    }


    public virtual long Count(Expression<Func<TEntity, bool>> filter)
    { 
        return BaseUnitOfWork().Repository<TEntity>().Query().Count(filter);
    }

    public virtual bool Any(Expression<Func<TEntity, bool>> filter)
    { 
        var result = BaseUnitOfWork().Repository<TEntity>().Query().Any(filter);
        return result;
    }

    

    public virtual async Task<AppResponse> DeleteById(int id)
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().DeleteById(id, false);
        AppResponse.Message = "Kayit Silme Basarili";
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    }

    public virtual async Task<AppResponse> DeleteSoftById(int id)
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().DeleteById(id);
        AppResponse.Message = "Kayit Silme Basarili";
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    }

    public virtual async Task<AppResponse> GetAll()
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().GetAllAsync();
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    }

    public virtual async Task<AppResponse> GetById(int id)
    {
        AppResponse.Data = await BaseUnitOfWork().Repository<TEntity>().GetByIdAsync(id);
        AppResponse.Status = ResponseStatus.SUCCESS;
        return AppResponse;
    } 
}
