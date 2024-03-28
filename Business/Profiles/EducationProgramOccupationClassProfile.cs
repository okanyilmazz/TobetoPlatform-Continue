using AutoMapper;
using Business.Dtos.Requests.EducationProgramOccupationClassRequests;
using Business.Dtos.Responses.EducationProgramOccupationClassResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramOccupationClassProfile : Profile
{
    public EducationProgramOccupationClassProfile()
    {
        CreateMap<EducationProgramOccupationClass, CreateEducationProgramOccupationClassRequest>().ReverseMap();
        CreateMap<EducationProgramOccupationClass, CreatedEducationProgramOccupationClassResponse>().ReverseMap();

        CreateMap<EducationProgramOccupationClass, DeletedEducationProgramOccupationClassResponse>().ReverseMap();

        CreateMap<EducationProgramOccupationClass, UpdateEducationProgramOccupationClassRequest>().ReverseMap();
        CreateMap<EducationProgramOccupationClass, UpdatedEducationProgramOccupationClassResponse>().ReverseMap();

        CreateMap<IPaginate<EducationProgramOccupationClass>, Paginate<GetListEducationProgramOccupationClassResponse>>().ReverseMap();

        CreateMap<EducationProgramOccupationClass, GetEducationProgramOccupationClassResponse>()
          .ForMember(destinationMember: response => response.EducationProgramName,
          memberOptions: opt => opt.MapFrom(epoc => epoc.EducationProgram.Name))
          .ForMember(destinationMember: response => response.OccupationClassName,
          memberOptions: opt => opt.MapFrom(epoc => epoc.OccupationClass.Name)).ReverseMap();

        CreateMap<EducationProgramOccupationClass, GetListEducationProgramOccupationClassResponse>()
            .ForMember(destinationMember: response => response.EducationProgramName,
            memberOptions: opt => opt.MapFrom(epoc => epoc.EducationProgram.Name))
            .ForMember(destinationMember: response => response.OccupationClassName,
            memberOptions: opt => opt.MapFrom(epoc => epoc.OccupationClass.Name)).ReverseMap();
    }
}
