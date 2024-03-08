using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAccountActivityMapDal : IRepository<AccountActivityMap, Guid>, IAsyncRepository<AccountActivityMap, Guid>
{
}


