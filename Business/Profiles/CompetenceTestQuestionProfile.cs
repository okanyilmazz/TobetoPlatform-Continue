using AutoMapper;
using Business.Dtos.Requests.CompetenceTestQuestionRequests;
using Business.Dtos.Responses.CompetenceTestQuestionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CompetenceTestQuestionProfile : Profile
{
    public CompetenceTestQuestionProfile()
    {
        CreateMap<CompetenceTestQuestion, CreateCompetenceTestQuestionRequest>().ReverseMap();
        CreateMap<CompetenceTestQuestion, CreatedCompetenceTestQuestionResponse>().ReverseMap();

        CreateMap<CompetenceTestQuestion, UpdateCompetenceTestQuestionRequest>().ReverseMap();
        CreateMap<CompetenceTestQuestion, UpdatedCompetenceTestQuestionResponse>().ReverseMap();

        CreateMap<CompetenceTestQuestion, DeleteCompetenceTestQuestionRequest>().ReverseMap();
        CreateMap<CompetenceTestQuestion, DeletedCompetenceTestQuestionResponse>().ReverseMap();

        CreateMap<IPaginate<CompetenceTestQuestion>, Paginate<GetListCompetenceTestQuestionResponse>>().ReverseMap();
        CreateMap<CompetenceTestQuestion, GetListCompetenceTestQuestionResponse>().ReverseMap();
    }
}
