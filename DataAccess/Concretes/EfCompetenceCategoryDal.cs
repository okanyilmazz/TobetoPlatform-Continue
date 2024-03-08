using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCompetenceCategoryDal : EfRepositoryBase<CompetenceCategory, Guid, TobetoPlatformContext>, ICompetenceCategoryDal
{
    public EfCompetenceCategoryDal(TobetoPlatformContext context) : base(context)
    {
    }
}