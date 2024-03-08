using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IOccupationDal : IRepository<Occupation, Guid>, IAsyncRepository<Occupation, Guid>
{
}
