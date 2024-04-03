using Business.Dtos.Requests.MediaNewImageRequests;
using Business.Dtos.Responses.MediaNewImageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IMediaNewImageService
{

    Task<UpdatedMediaNewImageResponse> UpdateAsync(UpdateMediaNewImageRequest updateMediaNewImageRequest);
    Task<CreatedMediaNewImageResponse> AddAsync(CreateMediaNewImageRequest createMediaNewImageRequest, string currentPath);
    Task<DeletedMediaNewImageResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListMediaNewImageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetMediaNewImageResponse> GetByIdAsync(Guid id);
    Task<GetMediaNewImageResponse> GetByMediaNewIdAsync(Guid mewdiaNewId);
}
