using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IProductionCompanyDal : IRepository<ProductionCompany, Guid>, IAsyncRepository<ProductionCompany, Guid>
    {
    }
}

