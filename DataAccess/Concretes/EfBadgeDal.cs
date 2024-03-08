using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfBadgeDal : EfRepositoryBase<Badge, Guid, TobetoPlatformContext>, IBadgeDal
{
    public EfBadgeDal(TobetoPlatformContext context) : base(context)
    {
    }
}