using Business.Dtos.Requests.MediaNewRequests;
using Business.Dtos.Responses.MediaNewResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IMediaNewService
{
    Task<CreatedMediaNewResponse> AddAsync(CreateMediaNewRequest createMediaNewRequest);
    Task<UpdatedMediaNewResponse> UpdateAsync(UpdateMediaNewRequest updateMediaNewRequest);
    Task<DeletedMediaNewResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListMediaNewResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetMediaNewResponse> GetByIdAsync(Guid id);
}