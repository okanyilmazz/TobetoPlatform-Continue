using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfEducationProgramDevelopmentDal : EfRepositoryBase<EducationProgramDevelopment, Guid, TobetoPlatformContext>, IEducationProgramDevelopmentDal
{
    public EfEducationProgramDevelopmentDal(TobetoPlatformContext context) : base(context)
    {
    }
}
