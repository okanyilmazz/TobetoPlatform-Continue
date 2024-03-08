using AutoMapper;
using Business.Dtos.Requests.LanguageRequests;
using Business.Dtos.Responses.LanguageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, CreateLanguageRequest>().ReverseMap();
        CreateMap<Language, CreatedLanguageResponse>().ReverseMap();

        CreateMap<Language, UpdateLanguageRequest>().ReverseMap();
        CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();

        CreateMap<Language, DeleteLanguageRequest>().ReverseMap();
        CreateMap<Language, DeletedLanguageResponse>().ReverseMap();

        CreateMap<IPaginate<Language>, Paginate<GetListLanguageResponse>>().ReverseMap();
        CreateMap<Language, GetLanguageResponse>().ReverseMap();
        CreateMap<Language, GetListLanguageResponse>().ReverseMap();

        CreateMap<List<Language>, Paginate<GetListLanguageResponse>>().ForMember(destinationMember: h => h.Items,
         memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();
    }
}
