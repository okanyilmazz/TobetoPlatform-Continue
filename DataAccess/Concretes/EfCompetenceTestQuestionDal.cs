using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCompetenceTestQuestionDal : EfRepositoryBase<CompetenceTestQuestion, Guid, TobetoPlatformContext>, ICompetenceTestQuestionDal
{
    public EfCompetenceTestQuestionDal(TobetoPlatformContext context) : base(context)
    {
    }
}
