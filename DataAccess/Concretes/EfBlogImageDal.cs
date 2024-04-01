using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfBlogImageDal : EfRepositoryBase<BlogImage, Guid, TobetoPlatformContext>, IBlogImageDal
{
    public EfBlogImageDal(TobetoPlatformContext context) : base(context)
    {
    }
}
