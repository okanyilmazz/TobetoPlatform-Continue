using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ISubjectDal : IRepository<Subject, Guid>, IAsyncRepository<Subject, Guid>
{
}
