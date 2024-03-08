using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICompetenceResultDal : IRepository<CompetenceResult, Guid>, IAsyncRepository<CompetenceResult, Guid>
{
}
