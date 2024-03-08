using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
	public interface IQuestionTypeDal: IRepository<QuestionType, Guid>, IAsyncRepository<QuestionType, Guid>
    {
	}
}

