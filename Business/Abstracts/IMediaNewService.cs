using Business.Dtos.Requests.MediaNewRequests;
using Business.Dtos.Responses.MediaNewResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IMediaNewService
    {
        Task<CreatedMediaNewResponse> AddAsync(CreateMediaNewRequest createMediaNewRequest);
        Task<UpdatedMediaNewResponse> UpdateAsync(UpdateMediaNewRequest updateMediaNewRequest);
        Task<DeletedMediaNewResponse> DeleteAsync(DeleteMediaNewRequest deleteMediaNewRequest);
        Task<IPaginate<GetListMediaNewResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListMediaNewResponse> GetByIdAsync(Guid id);
    }
}