using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountAnswerDal : IRepository<AccountAnswer, Guid>, IAsyncRepository<AccountAnswer, Guid>
{
}
