using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCityDal : EfRepositoryBase<City, Guid, TobetoPlatformContext>, ICityDal
{
    public EfCityDal(TobetoPlatformContext context) : base(context)
    {
    }
}
