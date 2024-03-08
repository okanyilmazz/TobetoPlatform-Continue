using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountCompetenceTestDal : EfRepositoryBase<AccountCompetenceTest, Guid, TobetoPlatformContext>, IAccountCompetenceTestDal
{
    public EfAccountCompetenceTestDal(TobetoPlatformContext context) : base(context)
    {
    }
}
