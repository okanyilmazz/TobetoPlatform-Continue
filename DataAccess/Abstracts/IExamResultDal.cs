using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IExamResultDal : IRepository<ExamResult, Guid>, IAsyncRepository<ExamResult, Guid>
    {
    }
}

