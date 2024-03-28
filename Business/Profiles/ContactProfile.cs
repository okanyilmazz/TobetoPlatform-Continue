using AutoMapper;
using Business.Dtos.Requests.ContactRequests;
using Business.Dtos.Responses.ContactResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, CreateContactRequest>().ReverseMap();
        CreateMap<Contact, CreatedContactResponse>().ReverseMap();

        CreateMap<Contact, UpdateContactRequest>().ReverseMap();
        CreateMap<Contact, UpdatedContactResponse>().ReverseMap();

        CreateMap<Contact, DeletedContactResponse>().ReverseMap();

        CreateMap<Contact, GetListContactResponse>().ReverseMap();
        CreateMap<Contact, GetContactResponse>().ReverseMap();

        CreateMap<IPaginate<Contact>, Paginate<GetListContactResponse>>().ReverseMap();
    }
}
