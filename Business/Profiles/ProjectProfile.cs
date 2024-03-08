using AutoMapper;
using Business.Dtos.Requests.ProjectRequests;
using Business.Dtos.Responses.ProjectResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, CreateProjectRequest>().ReverseMap();
            CreateMap<Project, CreatedProjectResponse>().ReverseMap();

            CreateMap<Project, UpdateProjectRequest>().ReverseMap();
            CreateMap<Project, UpdatedProjectResponse>().ReverseMap();

            CreateMap<Project, DeleteProjectRequest>().ReverseMap();
            CreateMap<Project, DeletedProjectResponse>().ReverseMap();

            CreateMap<Project, GetListProjectResponse>().ReverseMap();
            CreateMap<IPaginate<Project>, Paginate<GetListProjectResponse>>().ReverseMap();
        }
    }
}
