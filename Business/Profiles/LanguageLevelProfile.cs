using AutoMapper;
using Business.Dtos.Requests.LanguageLevelRequests;
using Business.Dtos.Responses.LanguageLevelResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LanguageLevelProfile : Profile
    {
        public LanguageLevelProfile()
        {
            CreateMap<LanguageLevel, CreateLanguageLevelRequest>().ReverseMap();
            CreateMap<LanguageLevel, CreatedLanguageLevelResponse>().ReverseMap();

            CreateMap<LanguageLevel, UpdateLanguageLevelRequest>().ReverseMap();
            CreateMap<LanguageLevel, UpdatedLanguageLevelResponse>().ReverseMap();

            CreateMap<LanguageLevel, DeleteLanguageLevelRequest>().ReverseMap();
            CreateMap<LanguageLevel, DeletedLanguageLevelResponse>().ReverseMap();

            CreateMap<LanguageLevel, GetListLanguageLevelResponse>().ReverseMap();
            CreateMap<IPaginate<LanguageLevel>, Paginate<GetListLanguageLevelResponse>>().ReverseMap();
        }
    }
}
