using AutoMapper;
using Business.Dtos.Requests.EducationProgramProgrammingLanguageRequests;
using Business.Dtos.Responses.EducationProgramProgrammingLanguageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramProgrammingLanguageProfile : Profile

{
    public EducationProgramProgrammingLanguageProfile()
    {
        CreateMap<EducationProgramProgrammingLanguage, CreateEducationProgramProgrammingLanguageRequest>().ReverseMap();
        CreateMap<EducationProgramProgrammingLanguage, CreatedEducationProgramProgrammingLanguageResponse>().ReverseMap();

        CreateMap<EducationProgramProgrammingLanguage, DeletedEducationProgramProgrammingLanguageResponse>().ReverseMap();

        CreateMap<EducationProgramProgrammingLanguage, UpdateEducationProgramProgrammingLanguageRequest>().ReverseMap();
        CreateMap<EducationProgramProgrammingLanguage, UpdatedEducationProgramProgrammingLanguageResponse>().ReverseMap();

        CreateMap<IPaginate<EducationProgramProgrammingLanguage>, Paginate<GetListEducationProgramProgrammingLanguageResponse>>().ReverseMap();

        CreateMap<EducationProgramProgrammingLanguage, GetEducationProgramProgrammingLanguageResponse>()
         .ForMember(destinationMember: response => response.EducationProgramName,
         memberOptions: opt => opt.MapFrom(eppl => eppl.EducationProgram))
         .ForMember(destinationMember: response => response.ProgrammingLanguageName,
         memberOptions: opt => opt.MapFrom(eppl => eppl.ProgrammingLanguage))
         .ReverseMap();

        CreateMap<EducationProgramProgrammingLanguage, GetListEducationProgramProgrammingLanguageResponse>()
            .ForMember(destinationMember: response => response.EducationProgramName,
            memberOptions: opt => opt.MapFrom(eppl => eppl.EducationProgram))
            .ForMember(destinationMember: response => response.ProgrammingLanguageName,
            memberOptions: opt => opt.MapFrom(eppl => eppl.ProgrammingLanguage))
            .ReverseMap();
    }
}
