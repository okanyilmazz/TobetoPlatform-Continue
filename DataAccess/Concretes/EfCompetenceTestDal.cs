using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCompetenceTestDal : EfRepositoryBase<CompetenceTest, Guid, TobetoPlatformContext>, ICompetenceTestDal
{
    public EfCompetenceTestDal(TobetoPlatformContext context) : base(context)
    {
    }
}
