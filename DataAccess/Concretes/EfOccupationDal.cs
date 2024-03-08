using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfOccupationDal : EfRepositoryBase<Occupation, Guid, TobetoPlatformContext>, IOccupationDal
{
    public EfOccupationDal(TobetoPlatformContext context) : base(context)
    {
    }
}
