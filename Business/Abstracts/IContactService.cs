using Business.Dtos.Requests.ContactRequests;
using Business.Dtos.Responses.ContactResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IContactService
    {
        Task<CreatedContactResponse> AddAsync(CreateContactRequest createContactRequest);
        Task<UpdatedContactResponse> UpdateAsync(UpdateContactRequest updateContactRequest);
        Task<DeletedContactResponse> DeleteAsync(DeleteContactRequest deleteContactRequest);
        Task<IPaginate<GetListContactResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListContactResponse> GetByIdAsync(Guid id);

    }
}
