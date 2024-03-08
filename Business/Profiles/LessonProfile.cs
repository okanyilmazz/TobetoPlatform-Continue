using AutoMapper;
using Business.Dtos.Requests.LessonRequests;
using Business.Dtos.Responses.LessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
        CreateMap<Lesson, CreateLessonRequest>().ReverseMap();
        CreateMap<Lesson, DeleteLessonRequest>().ReverseMap();
        CreateMap<Lesson, UpdateLessonRequest>().ReverseMap();
        CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();
        CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();
        CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();
        CreateMap<IPaginate<Lesson>, Paginate<GetListLessonResponse>>().ReverseMap();
        CreateMap<Lesson, GetLessonResponse>().
            ForMember(destinationMember: l => l.ProductionCompanyName,
            memberOptions: gl => gl.MapFrom(gll => gll.ProductionCompany.Name)).
            ForMember(destinationMember: l => l.LessonModuleName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonModule.Name)).
            ForMember(destinationMember: l => l.LessonSubTypeName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonSubType.Name)).
            ForMember(destinationMember: l => l.LessonCategoryName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonCategory.Name)).
            ForMember(destinationMember: l => l.LanguageName,
            memberOptions: gl => gl.MapFrom(gll => gll.Language.Name))
            .ReverseMap();

        CreateMap<Lesson, GetListLessonResponse>().
            ForMember(destinationMember: l => l.ProductionCompanyName,
            memberOptions: gl => gl.MapFrom(gll => gll.ProductionCompany.Name)).
              ForMember(destinationMember: l => l.LessonModuleName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonModule.Name)).
              ForMember(destinationMember: l => l.LessonSubTypeName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonSubType.Name)).
              ForMember(destinationMember: l => l.LessonCategoryName,
            memberOptions: gl => gl.MapFrom(gll => gll.LessonCategory.Name)).
                ForMember(destinationMember: l => l.LanguageName,
            memberOptions: gl => gl.MapFrom(gll => gll.Language.Name))
            .ReverseMap();

       

        CreateMap<List<Lesson>, Paginate<GetListLessonResponse>>().ForMember
        (destinationMember: a => a.Items, memberOptions: l => l.MapFrom(l => l.ToList())).ReverseMap();
    }
}
