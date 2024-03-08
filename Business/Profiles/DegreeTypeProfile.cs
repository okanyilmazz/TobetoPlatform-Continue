using AutoMapper;
using Business.Dtos.Requests.DegreeTypeRequests;
using Business.Dtos.Responses.DegreeTypeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class DegreeTypeProfile : Profile
    {
        public DegreeTypeProfile()
        {
            CreateMap<DegreeType, CreateDegreeTypeRequest>().ReverseMap();
            CreateMap<DegreeType, CreatedDegreeTypeResponse>().ReverseMap();

            CreateMap<DegreeType, DeleteDegreeTypeRequest>().ReverseMap();
            CreateMap<DegreeType, DeletedDegreeTypeResponse>().ReverseMap();

            CreateMap<DegreeType, UpdateDegreeTypeRequest>().ReverseMap();
            CreateMap<DegreeType, UpdatedDegreeTypeResponse>().ReverseMap();

            CreateMap<IPaginate<DegreeType>, Paginate<GetListDegreeTypeResponse>>().ReverseMap();
            CreateMap<DegreeType, GetListDegreeTypeResponse>().ReverseMap();
        }
    }
}
