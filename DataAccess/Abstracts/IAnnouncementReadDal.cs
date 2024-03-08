using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAnnouncementReadDal : IRepository<AnnouncementRead,Guid> ,IAsyncRepository<AnnouncementRead, Guid>
{
}
