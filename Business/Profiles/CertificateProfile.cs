using AutoMapper;
using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.CertificateResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        CreateMap<Certificate, CreateCertificateRequest>().ReverseMap();
        CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();

        CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
        CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();

        CreateMap<Certificate, DeleteCertificateRequest>().ReverseMap();
        CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();

        CreateMap<Certificate, GetListCertificateResponse>().ReverseMap();
        CreateMap<Certificate, GetCertificateResponse>().ReverseMap();

        CreateMap<IPaginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();
    }
}
