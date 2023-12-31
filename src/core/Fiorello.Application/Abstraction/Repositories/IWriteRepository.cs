﻿using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Repositories;

public interface IWriteRepository<T> : IRepositoriesBase<T> where T : BaseEntity, new()
{
	Task AddAsync(T entity);
	Task AddRangeAsync(ICollection<T> entity);
	void Update(T entity);
	void Remove(T entity);
	void Remove(ICollection<T> entity);
	Task SaveChangeAsync();
}
