using AutoMapper;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponses;
using Core.DataAccess.Paging;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {

            CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, DeleteOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();

            CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

            CreateMap<OperationClaim, DeleteOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();

            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, Paginate<GetListOperationClaimResponse>>().ReverseMap();
        }
    }
} 
