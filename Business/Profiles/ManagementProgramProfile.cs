using AutoMapper;
using Business.Dtos.Requests.ManagementProgramRequests;
using Business.Dtos.Responses.ManagementProgramResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ManagementProgramProfile:Profile
{
    public ManagementProgramProfile()
    {
        CreateMap<ManagementProgram, CreateManagementProgramRequest>().ReverseMap();
        CreateMap<ManagementProgram, CreatedManagementProgramResponse>().ReverseMap();

        CreateMap<ManagementProgram, UpdateManagementProgramRequest>().ReverseMap();
        CreateMap<ManagementProgram, UpdatedManagementProgramResponse>().ReverseMap();

        CreateMap<ManagementProgram, DeletedManagementProgramResponse>().ReverseMap();


        CreateMap<IPaginate<ManagementProgram>, Paginate<GetListManagementProgramResponse>>().ReverseMap();
        CreateMap<ManagementProgram, GetListManagementProgramResponse>().ReverseMap();
        CreateMap<ManagementProgram, GetManagementProgramResponse>().ReverseMap();
    }
}
