using AutoMapper;
using Business.Dtos.Requests.CompetenceRequests;
using Business.Dtos.Responses.CompetenceResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CompetenceCategoryProfile : Profile
{
    public CompetenceCategoryProfile()
    {
        CreateMap<CompetenceCategory, CreateCompetenceCategoryRequest>().ReverseMap();
        CreateMap<CompetenceCategory, CreatedCompetenceCategoryResponse>().ReverseMap();

        CreateMap<CompetenceCategory, UpdateCompetenceCategoryRequest>().ReverseMap();
        CreateMap<CompetenceCategory, UpdatedCompetenceCategoryResponse>().ReverseMap();

        CreateMap<CompetenceCategory, DeleteCompetenceCategoryRequest>().ReverseMap();
        CreateMap<CompetenceCategory, DeletedCompetenceCategoryResponse>().ReverseMap();

        CreateMap<CompetenceCategory, GetListCompetenceCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<CompetenceCategory>, Paginate<GetListCompetenceCategoryResponse>>().ReverseMap();
    }
}