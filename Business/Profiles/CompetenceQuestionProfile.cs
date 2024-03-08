using AutoMapper;
using Business.Dtos.Requests.CompetenceQuestionRequests;
using Business.Dtos.Responses.CompetenceQuestionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CompetenceQuestionProfile : Profile
{
    public CompetenceQuestionProfile()
    {
        CreateMap<CompetenceQuestion, CreateCompetenceQuestionRequest>().ReverseMap();
        CreateMap<CompetenceQuestion, CreatedCompetenceQuestionResponse>().ReverseMap();

        CreateMap<CompetenceQuestion, UpdateCompetenceQuestionRequest>().ReverseMap();
        CreateMap<CompetenceQuestion, UpdatedCompetenceQuestionResponse>().ReverseMap();

        CreateMap<CompetenceQuestion, DeleteCompetenceQuestionRequest>().ReverseMap();
        CreateMap<CompetenceQuestion, DeletedCompetenceQuestionResponse>().ReverseMap();

        CreateMap<CompetenceQuestion, GetListCompetenceQuestionResponse>().ReverseMap();

        CreateMap<IPaginate<CompetenceQuestion>, Paginate<GetListCompetenceQuestionResponse>>().ReverseMap();
    }
}