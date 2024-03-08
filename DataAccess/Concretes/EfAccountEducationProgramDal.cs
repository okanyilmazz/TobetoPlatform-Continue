using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountEducationProgramDal : EfRepositoryBase<AccountEducationProgram, Guid, TobetoPlatformContext>, IAccountEducationProgramDal
{
    public EfAccountEducationProgramDal(TobetoPlatformContext context) : base(context)
    {
    }
}
