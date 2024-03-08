using AutoMapper;
using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Dtos.Responses.EducationProgramLikeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramLikeProfile : Profile
{
    public EducationProgramLikeProfile()
    {
        CreateMap<EducationProgramLike, CreateEducationProgramLikeRequest>().ReverseMap();
        CreateMap<EducationProgramLike, CreatedEducationProgramLikeResponse>().ReverseMap();

        CreateMap<EducationProgramLike, UpdateEducationProgramLikeRequest>().ReverseMap();
        CreateMap<EducationProgramLike, UpdatedEducationProgramLikeResponse>().ReverseMap();

        CreateMap<EducationProgramLike, DeleteEducationProgramLikeRequest>().ReverseMap();
        CreateMap<EducationProgramLike, DeletedEducationProgramLikeResponse>().ReverseMap();

        CreateMap<EducationProgramLike, GetListEducationProgramLikeResponse>().ReverseMap();
        CreateMap<IPaginate<EducationProgramLike>, Paginate<GetListEducationProgramLikeResponse>>().ReverseMap();
    }
}