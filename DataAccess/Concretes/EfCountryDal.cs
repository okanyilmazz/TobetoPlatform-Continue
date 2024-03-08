using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCountryDal : EfRepositoryBase<Country, Guid, TobetoPlatformContext>, ICountryDal

{
    public EfCountryDal(TobetoPlatformContext context) : base(context)
    {

    }
}
