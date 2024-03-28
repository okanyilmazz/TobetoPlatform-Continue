using AutoMapper;
using Business.Dtos.Requests.OccupationClassSurveyRequests;
using Business.Dtos.Responses.OccupationClassSurveyResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class OccupationClassSurveyProfile : Profile
{
    public OccupationClassSurveyProfile()
    {
        CreateMap<OccupationClassSurvey, CreateOccupationClassSurveyRequest>().ReverseMap();
        CreateMap<OccupationClassSurvey, CreatedOccupationClassSurveyResponse>().ReverseMap();

        CreateMap<OccupationClassSurvey, DeletedOccupationClassSurveyResponse>().ReverseMap();

        CreateMap<OccupationClassSurvey, UpdateOccupationClassSurveyRequest>().ReverseMap();
        CreateMap<OccupationClassSurvey, UpdatedOccupationClassSurveyResponse>().ReverseMap();

        CreateMap<IPaginate<OccupationClassSurvey>, Paginate<GetListOccupationClassSurveyResponse>>().ReverseMap();
        CreateMap<OccupationClassSurvey, GetListOccupationClassSurveyResponse>()
            .ForMember(destinationMember: response => response.SurveyName,
            memberOptions: opt => opt.MapFrom(ocs => ocs.Survey.Title))
            .ForMember(destinationMember: response => response.OccupationClassName,
            memberOptions: opt => opt.MapFrom(ocs => ocs.OccupationClass.Name))
        .ReverseMap();
        CreateMap<OccupationClassSurvey, GetOccupationClassSurveyResponse>()
          .ForMember(destinationMember: response => response.SurveyName,
          memberOptions: opt => opt.MapFrom(ocs => ocs.Survey.Title))
          .ForMember(destinationMember: response => response.OccupationClassName,
          memberOptions: opt => opt.MapFrom(ocs => ocs.OccupationClass.Name))
      .ReverseMap();
    }
}
