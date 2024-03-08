using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountBadgeDal : IRepository<AccountBadge, Guid>, IAsyncRepository<AccountBadge, Guid>
{
}
