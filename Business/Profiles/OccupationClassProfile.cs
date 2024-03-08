using AutoMapper;
using Business.Dtos.Requests.OccupationClassRequests;
using Business.Dtos.Responses.OccupationClassResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class OccupationClassProfile : Profile
    {
        public OccupationClassProfile()
        {
            CreateMap<OccupationClass, CreateOccupationClassRequest>().ReverseMap();
            CreateMap<OccupationClass, CreatedOccupationClassResponse>().ReverseMap();

            CreateMap<OccupationClass, DeleteOccupationClassRequest>().ReverseMap();
            CreateMap<OccupationClass, DeletedOccupationClassResponse>().ReverseMap();

            CreateMap<OccupationClass, UpdateOccupationClassRequest>().ReverseMap();
            CreateMap<OccupationClass, UpdatedOccupationClassResponse>().ReverseMap();

            CreateMap<IPaginate<OccupationClass>, Paginate<GetListOccupationClassResponse>>().ReverseMap();
            CreateMap<OccupationClass, GetListOccupationClassResponse>().ReverseMap();
        }
    }
}
