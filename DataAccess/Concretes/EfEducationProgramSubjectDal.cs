using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfEducationProgramSubjectDal : EfRepositoryBase<EducationProgramSubject, Guid, TobetoPlatformContext>, IEducationProgramSubjectDal
{
    public EfEducationProgramSubjectDal(TobetoPlatformContext context) : base(context)
    {
    }
}
