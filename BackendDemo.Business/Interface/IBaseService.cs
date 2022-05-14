using BackendDemo.SharedLibrary.DTOs;
using BackendDemo.Core.DTOs;
using BackendDemo.Core.Entities;
using System.Linq.Expressions;

namespace BackendDemo.Business.Base;

public interface IBaseService<TEntity, TDto>
    where TEntity : BaseEntity
    where TDto : BaseDTO
{
    Task<AppResponse> GetAll();

    Task<AppResponse> GetById(long id);

    Task<AppResponse> Add(TDto entity);

    Task<AppResponse> Update(TDto entity);

    long Count();

    long Count(Expression<Func<TEntity, bool>> filter);

    bool Any(Expression<Func<TEntity, bool>> filter);

    Task<AppResponse> DeleteById(long id);

    Task<AppResponse> DeleteSoftById(long id);
}
