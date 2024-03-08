using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfProgrammingLanguageDal : EfRepositoryBase<ProgrammingLanguage, Guid, TobetoPlatformContext>, IProgrammingLanguageDal
    {
        public EfProgrammingLanguageDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
