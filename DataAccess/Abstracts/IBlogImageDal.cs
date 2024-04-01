using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBlogImageDal : IRepository<BlogImage, Guid>, IAsyncRepository<BlogImage, Guid>
{
}
