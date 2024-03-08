using AutoMapper;
using Business.Dtos.Requests.CompetenceTestRequests;
using Business.Dtos.Responses.CompetenceTestResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CompetenceTestProfile:Profile
{
    public CompetenceTestProfile()
    {
        CreateMap<CompetenceTest, CreateCompetenceTestRequest>().ReverseMap();
        CreateMap<CompetenceTest, CreatedCompetenceTestResponse>().ReverseMap();

        CreateMap<CompetenceTest, UpdateCompetenceTestRequest>().ReverseMap();
        CreateMap<CompetenceTest, UpdatedCompetenceTestResponse>().ReverseMap();

        CreateMap<CompetenceTest, DeleteCompetenceTestRequest>().ReverseMap();
        CreateMap<CompetenceTest, DeletedCompetenceTestResponse>().ReverseMap();

        CreateMap<IPaginate<CompetenceTest>, Paginate<GetListCompetenceTestResponse>>().ReverseMap();
        CreateMap<CompetenceTest, GetListCompetenceTestResponse>().ReverseMap();
        CreateMap<CompetenceTest, GetCompetenceTestResponse>().ReverseMap();

    }
}
