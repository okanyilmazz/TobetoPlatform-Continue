using AutoMapper;
using Business.Dtos.Requests.SurveyRequests;
using Business.Dtos.Responses.SurveyResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class SurveyProfile : Profile
{
    public SurveyProfile()
    {
        CreateMap<Survey, CreateSurveyRequest>().ReverseMap();
        CreateMap<Survey, UpdateSurveyRequest>().ReverseMap();
        CreateMap<Survey, DeleteSurveyRequest>().ReverseMap();

        CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

        CreateMap<Survey, GetListSurveyResponse>().ReverseMap();
        CreateMap<Survey, GetSurveyResponse>().ReverseMap();
        CreateMap<IPaginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();
    }
}
