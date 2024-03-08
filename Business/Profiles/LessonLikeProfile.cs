using AutoMapper;
using Business.Dtos.Requests.LessonLikeRequests;
using Business.Dtos.Responses.LessonLikeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonLikeProfile : Profile
{
    public LessonLikeProfile()
    {
        CreateMap<LessonLike, CreateLessonLikeRequest>().ReverseMap();
        CreateMap<LessonLike, CreatedLessonLikeResponse>().ReverseMap();

        CreateMap<LessonLike, UpdateLessonLikeRequest>().ReverseMap();
        CreateMap<LessonLike, UpdatedLessonLikeResponse>().ReverseMap();

        CreateMap<LessonLike, DeleteLessonLikeRequest>().ReverseMap();
        CreateMap<LessonLike, DeletedLessonLikeResponse>().ReverseMap();

        CreateMap<LessonLike, GetListLessonLikeResponse>().ReverseMap();
        CreateMap<LessonLike, GetLessonLikeResponse>().ReverseMap();
        CreateMap<IPaginate<LessonLike>, Paginate<GetListLessonLikeResponse>>().ReverseMap();
    }
}
