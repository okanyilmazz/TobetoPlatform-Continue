using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICompetenceTestQuestionDal : IRepository<CompetenceTestQuestion, Guid>, IAsyncRepository<CompetenceTestQuestion, Guid>
{
}
