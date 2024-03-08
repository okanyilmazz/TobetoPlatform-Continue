using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfManagementProgramDal : EfRepositoryBase<ManagementProgram, Guid, TobetoPlatformContext>, IManagementProgramDal
{
    public EfManagementProgramDal(TobetoPlatformContext context) : base(context)
    {
    }
}
