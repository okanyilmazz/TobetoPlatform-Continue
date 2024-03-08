using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfEducationProgramProgrammingLanguageDal : EfRepositoryBase<EducationProgramProgrammingLanguage, Guid, TobetoPlatformContext>, IEducationProgramProgrammingLanguageDal
    {
        public EfEducationProgramProgrammingLanguageDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
