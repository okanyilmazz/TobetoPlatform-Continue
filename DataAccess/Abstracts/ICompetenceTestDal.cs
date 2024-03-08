using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICompetenceTestDal : IRepository<CompetenceTest, Guid>, IAsyncRepository<CompetenceTest, Guid>
{
}
