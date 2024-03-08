using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfSubjectDal : EfRepositoryBase<Subject, Guid, TobetoPlatformContext>, ISubjectDal
{
    public EfSubjectDal(TobetoPlatformContext context) : base(context)
    {
    }
}
