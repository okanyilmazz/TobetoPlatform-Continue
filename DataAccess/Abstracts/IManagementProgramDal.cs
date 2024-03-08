using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IManagementProgramDal:IRepository<ManagementProgram,Guid>, IAsyncRepository<ManagementProgram,Guid>
{
}
