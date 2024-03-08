using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfEducationLikeDal : EfRepositoryBase<EducationProgramLike, Guid, TobetoPlatformContext>, IEducationProgramLikeDal
{
    public EfEducationLikeDal(TobetoPlatformContext context) : base(context)
    {
    }
}
