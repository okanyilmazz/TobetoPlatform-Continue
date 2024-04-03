using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfMediaNewImageDal : EfRepositoryBase<MediaNewImage, Guid, TobetoPlatformContext>, IMediaNewImageDal
{
    public EfMediaNewImageDal(TobetoPlatformContext context) : base(context)
    {
    }
}
