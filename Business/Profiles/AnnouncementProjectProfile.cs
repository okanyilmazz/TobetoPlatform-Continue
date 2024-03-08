using AutoMapper;
using Business.Dtos.Requests.AnnouncementProjectRequests;
using Business.Dtos.Responses.AnnouncementProjectResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AnnouncementProjectProfile : Profile
    {
        public AnnouncementProjectProfile()
        {
            CreateMap<AnnouncementProject, CreateAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, CreatedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, UpdateAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, UpdatedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, DeleteAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, DeletedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, GetListAnnouncementProjectResponse>()
                //.ForMember(destinationMember:response=>response.AnnouncementName,memberOptions:
                //opt=>opt.MapFrom(ap=>ap.Announcement.Title))
                //.ForMember(destinationMember:response=>response.ProjectName,memberOptions:
                //opt=>opt.MapFrom(ap=>ap.Project.Name))
                 .ForMember(destinationMember: response => response.Announcement, memberOptions:
                opt => opt.MapFrom(ap => ap.Announcement))
                .ForMember(destinationMember: response => response.Project, memberOptions:
                opt => opt.MapFrom(ap => ap.Project))

                .ReverseMap();
            CreateMap<IPaginate<AnnouncementProject>, Paginate<GetListAnnouncementProjectResponse>>().ReverseMap();

            
        }
    }
}
