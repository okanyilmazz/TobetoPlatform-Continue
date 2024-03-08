using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICompetenceQuestionDal : IRepository<CompetenceQuestion, Guid>, IAsyncRepository<CompetenceQuestion, Guid>
{
}
