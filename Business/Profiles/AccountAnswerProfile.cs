using AutoMapper;
using Business.Dtos.Requests.AccountAnswerRequests;
using Business.Dtos.Responses.AccountAnswerResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountAnswerProfile : Profile
{
    public AccountAnswerProfile()
    {
        CreateMap<AccountAnswer, CreateAccountAnswerRequest>().ReverseMap();
        CreateMap<AccountAnswer, CreatedAccountAnswerResponse>().ReverseMap();

        CreateMap<AccountAnswer, UpdateAccountAnswerRequest>().ReverseMap();
        CreateMap<AccountAnswer, UpdatedAccountAnswerResponse>().ReverseMap();

        CreateMap<AccountAnswer, DeletedAccountAnswerResponse>().ReverseMap();
        CreateMap<AccountAnswer, GetAccountAnswerResponse>()
            .ForMember(destinationMember: caar => caar.ExamName,
            memberOptions: opt => opt.MapFrom(aa => aa.Exam.Name))

             .ForMember(destinationMember: caar => caar.AccountName,
             memberOptions: opt => opt.MapFrom(aa => aa.Account.User.FirstName))

             .ForMember(destinationMember: caar => caar.QuestionName,
             memberOptions: opt => opt.MapFrom(aa => aa.Question.Description)).ReverseMap();

        CreateMap<AccountAnswer, GetListAccountAnswerResponse>()
             .ForMember(destinationMember: caar => caar.ExamName,
            memberOptions: opt => opt.MapFrom(aa => aa.Exam.Name))

             .ForMember(destinationMember: caar => caar.AccountName,
             memberOptions: opt => opt.MapFrom(aa => aa.Account.User.FirstName))

             .ForMember(destinationMember: caar => caar.QuestionName,
             memberOptions: opt => opt.MapFrom(aa => aa.Question.Description)).ReverseMap();

        CreateMap<IPaginate<AccountAnswer>, Paginate<GetListAccountAnswerResponse>>().ReverseMap();
    }
}
