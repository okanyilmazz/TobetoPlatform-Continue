using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountViewLessonDal : EfRepositoryBase<AccountViewLesson, Guid, TobetoPlatformContext>, IAccountViewLessonDal
{
    public EfAccountViewLessonDal(TobetoPlatformContext context) : base(context)
    {
    }
}
