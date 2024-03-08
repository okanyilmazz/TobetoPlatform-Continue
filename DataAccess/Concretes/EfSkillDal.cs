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
    public class EfSkillDal : EfRepositoryBase<Skill, Guid, TobetoPlatformContext>, ISkillDal
    {
        public EfSkillDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
