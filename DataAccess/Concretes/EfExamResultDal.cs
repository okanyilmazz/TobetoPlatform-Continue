using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{

    public class EfExamResultDal : EfRepositoryBase<ExamResult, Guid, TobetoPlatformContext>, IExamResultDal
    {
        public EfExamResultDal(TobetoPlatformContext context) : base(context)
        {
        }
    }

}

