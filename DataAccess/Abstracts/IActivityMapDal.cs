using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

  public interface IActivityMapDal : IRepository<ActivityMap, Guid>, IAsyncRepository<ActivityMap, Guid>
    {
    }


