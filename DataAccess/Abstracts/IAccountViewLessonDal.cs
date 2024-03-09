using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountViewLessonDal : IAsyncRepository<AccountViewLesson, Guid>, IRepository<AccountViewLesson, Guid>
{
}
