using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEducationProgramLikeDal : IAsyncRepository<EducationProgramLike, Guid>, IRepository<EducationProgramLike, Guid>
{
}