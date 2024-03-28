using AutoMapper;
using Business.Dtos.Requests.LessonCategoryRequests;
using Business.Dtos.Responses.LessonCategoryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonCategoryProfile : Profile
{
    public LessonCategoryProfile()
    {
        CreateMap<LessonCategory, CreateLessonCategoryRequest>().ReverseMap();
        CreateMap<LessonCategory, UpdateLessonCategoryRequest>().ReverseMap();
        CreateMap<LessonCategory, CreatedLessonCategoryResponse>().ReverseMap();
        CreateMap<LessonCategory, DeletedLessonCategoryResponse>().ReverseMap();
        CreateMap<LessonCategory, UpdatedLessonCategoryResponse>().ReverseMap();
        CreateMap<IPaginate<LessonCategory>, Paginate<GetListLessonCategoryResponse>>().ReverseMap();
        CreateMap<LessonCategory, GetListLessonCategoryResponse>().ReverseMap();
        CreateMap<LessonCategory, GetLessonCategoryResponse>().ReverseMap();
    }
}
