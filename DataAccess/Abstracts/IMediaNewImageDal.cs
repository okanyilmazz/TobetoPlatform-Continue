using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IMediaNewImageDal : IRepository<MediaNewImage, Guid>, IAsyncRepository<MediaNewImage, Guid>
{
}
