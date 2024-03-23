using Business.Dtos.Requests.ContactRequests;
using Business.Dtos.Responses.ContactResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IContactService
{
    Task<CreatedContactResponse> AddAsync(CreateContactRequest createContactRequest);
    Task<UpdatedContactResponse> UpdateAsync(UpdateContactRequest updateContactRequest);
    Task<DeletedContactResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListContactResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetContactResponse> GetByIdAsync(Guid id);
}
