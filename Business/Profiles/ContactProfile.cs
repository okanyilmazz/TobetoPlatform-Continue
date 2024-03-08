using AutoMapper;
using Business.Dtos.Requests.ContactRequests;
using Business.Dtos.Responses.ContactResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateContactRequest>().ReverseMap();
            CreateMap<Contact, CreatedContactResponse>().ReverseMap();

            CreateMap<Contact, UpdateContactRequest>().ReverseMap();
            CreateMap<Contact, UpdatedContactResponse>().ReverseMap();

            CreateMap<Contact, DeleteContactRequest>().ReverseMap();
            CreateMap<Contact, DeletedContactResponse>().ReverseMap();

            CreateMap<Contact, GetListContactResponse>().ReverseMap();

            CreateMap<IPaginate<Contact>, Paginate<GetListContactResponse>>().ReverseMap();
        }
    }
}
