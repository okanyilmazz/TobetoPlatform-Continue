using AutoMapper;
using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using Business.Dtos.Responses.EducationProgramDevelopmentResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramDevelopmentProfile :Profile
{
    public EducationProgramDevelopmentProfile() {

        CreateMap<EducationProgramDevelopment, CreateEducationProgramDevelopmentRequest>().ReverseMap();
        CreateMap<EducationProgramDevelopment, CreatedEducationProgramDevelopmentResponse>().ReverseMap();

        CreateMap<EducationProgramDevelopment, UpdateEducationProgramDevelopmentRequest>().ReverseMap();
        CreateMap<EducationProgramDevelopment, UpdatedEducationProgramDevelopmentResponse>().ReverseMap();

        CreateMap<EducationProgramDevelopment, DeleteEducationProgramDevelopmentRequest>().ReverseMap();
        CreateMap<EducationProgramDevelopment, DeletedEducationProgramDevelopmentResponse>().ReverseMap();

        CreateMap<EducationProgramDevelopment, GetListEducationProgramDevelopmentResponse>().ReverseMap();
        CreateMap<IPaginate<EducationProgramDevelopment>, Paginate<GetListEducationProgramDevelopmentResponse>>().ReverseMap();
    }
}
