using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountCompetenceTestDal : IRepository<AccountCompetenceTest, Guid>, IAsyncRepository<AccountCompetenceTest, Guid>
{
}
