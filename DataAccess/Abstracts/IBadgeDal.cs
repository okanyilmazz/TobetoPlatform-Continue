using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBadgeDal : IRepository<Badge, Guid>, IAsyncRepository<Badge, Guid>
{
}
