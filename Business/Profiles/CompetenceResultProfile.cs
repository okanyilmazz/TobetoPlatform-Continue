using AutoMapper;
using Business.Dtos.Requests.CompetenceResultRequests;
using Business.Dtos.Responses.CompetenceResultResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CompetenceResultProfile : Profile
{
    public CompetenceResultProfile()
    {

        CreateMap<CompetenceResult, CreateCompetenceResultRequest>().ReverseMap();
        CreateMap<CompetenceResult, CreatedCompetenceResultResponse>().ReverseMap();

        CreateMap<CompetenceResult, UpdateCompetenceResultRequest>().ReverseMap();
        CreateMap<CompetenceResult, UpdatedCompetenceResultResponse>().ReverseMap();

        CreateMap<CompetenceResult, DeletedCompetenceResultResponse>().ReverseMap();

        CreateMap<IPaginate<CompetenceResult>, Paginate<GetListCompetenceResultResponse>>().ReverseMap();
        CreateMap<CompetenceResult, GetListCompetenceResultResponse>().ReverseMap();
        CreateMap<CompetenceResult, GetCompetenceResultResponse>().ReverseMap();
    }
}
