
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountActivityMapDal : EfRepositoryBase<AccountActivityMap, Guid, TobetoPlatformContext>, IAccountActivityMapDal
{
    public EfAccountActivityMapDal(TobetoPlatformContext context) : base(context)
    {
    }
}

