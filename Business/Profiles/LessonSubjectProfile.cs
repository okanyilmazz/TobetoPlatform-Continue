using AutoMapper;
using Business.Dtos.Requests.SubjectRequests;
using Business.Dtos.Responses.SubjectResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class LessonSubjectProfile : Profile
    {
        public LessonSubjectProfile()
        {
            CreateMap<Subject, CreateSubjectRequest>().ReverseMap();
            CreateMap<Subject, UpdateSubjectRequest>().ReverseMap();
            CreateMap<Subject, DeleteSubjectRequest>().ReverseMap();

            CreateMap<Subject, CreatedSubjectResponse>().ReverseMap();
            CreateMap<Subject, UpdatedSubjectResponse>().ReverseMap();
            CreateMap<Subject, DeletedSubjectResponse>().ReverseMap();

            CreateMap<IPaginate<Subject>, Paginate<GetListSubjectResponse>>().ReverseMap();
            CreateMap<Subject, GetListSubjectResponse>().ReverseMap();
            CreateMap<Subject, GetSubjectResponse>().ReverseMap();
        }
    }
}