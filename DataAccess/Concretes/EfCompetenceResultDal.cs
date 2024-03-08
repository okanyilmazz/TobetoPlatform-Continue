using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCompetenceResultDal : EfRepositoryBase<CompetenceResult, Guid, TobetoPlatformContext>, ICompetenceResultDal
{
    public EfCompetenceResultDal(TobetoPlatformContext context) : base(context)
    {
    }
}