using AutoMapper;
using Business.Dtos.Requests.EducationProgramLevelRequests;
using Business.Dtos.Responses.EducationProgramLevelResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramLevelProfile : Profile
{
    public EducationProgramLevelProfile()
    {
        CreateMap<EducationProgramLevel, CreateEducationProgramLevelRequest>().ReverseMap();
        CreateMap<EducationProgramLevel, UpdateEducationProgramLevelRequest>().ReverseMap();

        CreateMap<EducationProgramLevel, CreatedEducationProgramLevelResponse>().ReverseMap();
        CreateMap<EducationProgramLevel, UpdatedEducationProgramLevelResponse>().ReverseMap();
        CreateMap<EducationProgramLevel, DeletedEducationProgramLevelResponse>().ReverseMap();

        CreateMap<IPaginate<EducationProgramLevel>, Paginate<GetListEducationProgramLevelResponse>>().ReverseMap();
        CreateMap<EducationProgramLevel, GetListEducationProgramLevelResponse>().ReverseMap();
        CreateMap<EducationProgramLevel, GetEducationProgramLevelResponse>().ReverseMap();
    }
}       
