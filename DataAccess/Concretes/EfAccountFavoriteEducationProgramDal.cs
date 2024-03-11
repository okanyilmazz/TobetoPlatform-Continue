using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountFavoriteEducationProgramDal : EfRepositoryBase<AccountFavoriteEducationProgram, Guid, TobetoPlatformContext>, IAccountFavoriteEducationProgramDal
{
    public EfAccountFavoriteEducationProgramDal(TobetoPlatformContext context) : base(context)
    {
    }
}
