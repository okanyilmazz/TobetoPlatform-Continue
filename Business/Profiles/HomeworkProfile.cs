using AutoMapper;
using Business.Dtos.Requests.HomeworkRequests;
using Business.Dtos.Responses.HomeworkResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class HomeworkProfile : Profile
{
    public HomeworkProfile()
    {
        CreateMap<Homework, CreateHomeworkRequest>().ReverseMap();
        CreateMap<Homework, CreatedHomeworkResponse>().ReverseMap();

        CreateMap<Homework, UpdateHomeworkRequest>().ReverseMap();
        CreateMap<Homework, UpdatedHomeworkResponse>().ReverseMap();

        CreateMap<Homework, DeleteHomeworkRequest>().ReverseMap();
        CreateMap<Homework, DeletedHomeworkResponse>().ReverseMap();

        CreateMap<IPaginate<Homework>, Paginate<GetListHomeworkResponse>>().ReverseMap();
        CreateMap<Homework, GetListHomeworkResponse>().ReverseMap();

        CreateMap<List<Homework>, Paginate<GetListHomeworkResponse>>().ForMember(destinationMember: h => h.Items,
            memberOptions: opt => opt.MapFrom(h=>h.ToList())).ReverseMap();

        CreateMap<Homework, GetListHomeworkResponse>()
          .ForMember(destinationMember: response => response.LessonName,
          memberOptions: opt => opt.MapFrom(h => h.Lesson.Name)).ReverseMap();
    }
}
