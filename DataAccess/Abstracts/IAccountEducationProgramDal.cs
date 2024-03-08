using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountEducationProgramDal : IRepository<AccountEducationProgram, Guid>, IAsyncRepository<AccountEducationProgram, Guid>
{
}
