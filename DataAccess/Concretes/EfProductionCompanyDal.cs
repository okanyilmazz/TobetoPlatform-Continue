using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfProductionCompanyDal : EfRepositoryBase<ProductionCompany, Guid, TobetoPlatformContext>, IProductionCompanyDal
    {
        public EfProductionCompanyDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}

