using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ILessonLikeDal : IAsyncRepository<LessonLike, Guid>, IRepository<LessonLike, Guid>
{
}
