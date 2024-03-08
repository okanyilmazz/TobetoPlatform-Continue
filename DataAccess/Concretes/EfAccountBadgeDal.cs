using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAccountBadgeDal : EfRepositoryBase<AccountBadge, Guid, TobetoPlatformContext>, IAccountBadgeDal
{
    public EfAccountBadgeDal(TobetoPlatformContext context) : base(context)
    {
    }
}