using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEducationProgramSubjectDal:IRepository<EducationProgramSubject,Guid>,IAsyncRepository<EducationProgramSubject,Guid>
{
}

