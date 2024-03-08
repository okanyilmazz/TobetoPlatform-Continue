using System;
using AutoMapper;
using Business.Dtos.Requests.CountryRequests;
using Business.Dtos.Responses.CountryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CreateCountryRequest>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();

        CreateMap<Country, UpdateCountryRequest>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();

        CreateMap<Country, DeleteCountryRequest>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();

        CreateMap<Country, GetListCountryResponse>().ReverseMap();
        CreateMap<IPaginate<Country>, Paginate<GetListCountryResponse>>().ReverseMap();
    }
}


