using AutoMapper;
using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses.LessonModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonModuleProfile : Profile
{
    public LessonModuleProfile()
    {
        CreateMap<LessonModule, CreateLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, CreatedLessonModuleResponse>().ReverseMap();

        CreateMap<LessonModule, UpdateLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, UpdatedLessonModuleResponse>().ReverseMap();

        CreateMap<LessonModule, DeleteLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, DeletedLessonModuleResponse>().ReverseMap();

        CreateMap<LessonModule, GetListLessonModuleResponse>().ReverseMap();
        CreateMap<LessonModule, GetLessonModuleResponse>().ReverseMap();
        CreateMap<IPaginate<LessonModule>, Paginate<GetListLessonModuleResponse>>().ReverseMap();
    }
}
