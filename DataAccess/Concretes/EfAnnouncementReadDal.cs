using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAnnouncementReadDal : EfRepositoryBase<AnnouncementRead, Guid, TobetoPlatformContext>, IAnnouncementReadDal
{
    public EfAnnouncementReadDal(TobetoPlatformContext context) : base(context)
    {
    }
}
