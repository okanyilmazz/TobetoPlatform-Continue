using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCompetenceQuestionDal : EfRepositoryBase<CompetenceQuestion, Guid, TobetoPlatformContext>, ICompetenceQuestionDal
{
    public EfCompetenceQuestionDal(TobetoPlatformContext context) : base(context)
    {
    }
}
