using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICompetenceCategoryDal : IRepository<CompetenceCategory, Guid>, IAsyncRepository<CompetenceCategory, Guid>
{
}