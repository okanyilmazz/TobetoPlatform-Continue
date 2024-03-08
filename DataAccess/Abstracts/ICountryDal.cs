using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICountryDal : IRepository<Country, Guid>, IAsyncRepository<Country, Guid>
{

}

