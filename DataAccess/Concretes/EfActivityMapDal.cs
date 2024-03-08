using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfActivityMapDal : EfRepositoryBase<ActivityMap, Guid, TobetoPlatformContext>, IActivityMapDal
    {
        public EfActivityMapDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}

