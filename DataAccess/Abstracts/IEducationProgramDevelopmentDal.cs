using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEducationProgramDevelopmentDal : IRepository<EducationProgramDevelopment,Guid>,IAsyncRepository<EducationProgramDevelopment,Guid>
{
}
