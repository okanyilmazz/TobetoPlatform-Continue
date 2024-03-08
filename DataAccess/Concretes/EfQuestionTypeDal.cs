
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Concretes
{
    public class EfQuestionTypeDal: EfRepositoryBase<QuestionType, Guid, TobetoPlatformContext>, IQuestionTypeDal
    {
        public EfQuestionTypeDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}

