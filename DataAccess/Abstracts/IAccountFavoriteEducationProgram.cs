using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountFavoriteEducationProgramDal : IAsyncRepository<AccountFavoriteEducationProgram, Guid>, IRepository<AccountFavoriteEducationProgram, Guid>
{
}
