using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAnnouncementTypeDal : IRepository<AnnouncementType ,Guid> ,IAsyncRepository<AnnouncementType, Guid>
{
}
