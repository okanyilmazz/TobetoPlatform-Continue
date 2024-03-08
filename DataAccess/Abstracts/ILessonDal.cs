using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;

namespace DataAccess.Abstracts
{
    public interface ILessonDal : IRepository<Lesson, Guid>, IAsyncRepository<Lesson, Guid>
    {
    }
}
