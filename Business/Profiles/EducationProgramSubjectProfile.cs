using AutoMapper;
using Business.Dtos.Requests.EducationProgramSubjectRequests;
using Business.Dtos.Responses.EducationProgramSubjectResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramSubjectProfile : Profile
{
    public EducationProgramSubjectProfile()
    {
        CreateMap<EducationProgramSubject, CreateEducationProgramSubjectRequest>().ReverseMap();
        CreateMap<EducationProgramSubject, CreatedEducationProgramSubjectResponse>().ReverseMap();

        CreateMap<EducationProgramSubject, UpdateEducationProgramSubjectRequest>().ReverseMap();
        CreateMap<EducationProgramSubject, UpdatedEducationProgramSubjectResponse>().ReverseMap();

        CreateMap<EducationProgramSubject, DeleteEducationProgramSubjectRequest>().ReverseMap();
        CreateMap<EducationProgramSubject, DeletedEducationProgramSubjectResponse>().ReverseMap();

        CreateMap<EducationProgramSubject, GetListEducationProgramSubjectResponse>().ReverseMap();
        CreateMap<IPaginate<EducationProgramSubject>, Paginate<GetListEducationProgramSubjectResponse>>().ReverseMap();
    }
}