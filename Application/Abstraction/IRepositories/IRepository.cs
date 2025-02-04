﻿using Domain.Entities;
using System.Data;

namespace Application.Abstraction.IRepositories;
public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(Guid id);
}