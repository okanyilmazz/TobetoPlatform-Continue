using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAnnouncementTypeDal : EfRepositoryBase<AnnouncementType, Guid, TobetoPlatformContext>, IAnnouncementTypeDal
{
    public EfAnnouncementTypeDal(TobetoPlatformContext context) : base(context)
    {
    }
}
