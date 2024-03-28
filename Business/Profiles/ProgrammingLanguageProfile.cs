using AutoMapper;
using Business.Dtos.Requests.ProgrammingLanguageRequests;
using Business.Dtos.Responses.ProgrammingLanguageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProgrammingLanguageProfile : Profile
{
    public ProgrammingLanguageProfile()
    {
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageRequest>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageResponse>().ReverseMap();

        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageRequest>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageResponse>().ReverseMap();

        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageResponse>().ReverseMap();

        CreateMap<ProgrammingLanguage, GetListProgrammingLanguageResponse>().ReverseMap();
        CreateMap<ProgrammingLanguage, GetProgrammingLanguageResponse>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, Paginate<GetListProgrammingLanguageResponse>>().ReverseMap();
    }
}
