using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.MediaNewImageRequests;
using Business.Dtos.Responses.MediaNewImageResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class MediaNewImageManager : IMediaNewImageService
{
    IMediaNewImageDal _mediaNewImageDal;
    IMapper _mapper;
    MediaNewImageBusinessRules _mediaNewImageBusinessRules;
    IFileHelper _fileHelper;

    public MediaNewImageManager(IMediaNewImageDal mediaNewImageDal, IMapper mapper, IFileHelper fileHelper, MediaNewImageBusinessRules mediaNewImageBusinessRules)

    {
        _mediaNewImageDal = mediaNewImageDal;
        _mapper = mapper;
        _fileHelper = fileHelper;
        _mediaNewImageBusinessRules = mediaNewImageBusinessRules;
    }



    public async Task<UpdatedMediaNewImageResponse> UpdateAsync(UpdateMediaNewImageRequest updateMediaNewImageRequest)
    {
        await _mediaNewImageBusinessRules.IsExistsMediaNewImage(updateMediaNewImageRequest.Id);

        /* Server */

        #region
        //MediaNewImage mediaNewImage = await _mediaNewImageDal.GetAsync(predicate: a => a.Id == updateMediaNewImageRequest.Id);
        //string newMediaNewImagePath = await _fileHelper.Update(updateMediaNewImageRequest.File, mediaNewImage.ImagePath);
        //mediaNewImage.ImagePath = newMediaNewImagePath;
        //await _mediaNewImageDal.UpdateAsync(mediaNewImage);
        //var mappedMediaNewImage = _mapper.Map<UpdatedMediaNewImageResponse>(mediaNewImage);
        //return mappedMediaNewImage;
        #endregion

        /* Localhost */

        #region
        MediaNewImage mediaNewImage = await _mediaNewImageDal.GetAsync(predicate: a => a.Id == updateMediaNewImageRequest.Id);
        string mediaNewImagePath = mediaNewImage.ImagePath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
        string newFolderPathForLocal = PathConstant.LocalImagePath + mediaNewImagePath;
        string newMediaNewImagePath = await _fileHelper.Update(updateMediaNewImageRequest.File, newFolderPathForLocal);
        string newImageLocalPath = newMediaNewImagePath.Replace(PathConstant.LocalImagePath, PathConstant.LocalBaseUrlImagePath);

        mediaNewImage.ImagePath = newImageLocalPath;
        await _mediaNewImageDal.UpdateAsync(mediaNewImage);
        var mappedMediaNewImage = _mapper.Map<UpdatedMediaNewImageResponse>(mediaNewImage);
        return mappedMediaNewImage;
        #endregion
    }

    public async Task<CreatedMediaNewImageResponse> AddAsync(CreateMediaNewImageRequest createMediaNewImageRequest, string currentPath)
    {

        /* Server */

        #region
        //var uploadResult = _fileHelper.Add(createMediaNewImageRequest.File, currentPath);
        //string newFolderPath = uploadResult.Result.Replace(currentPath, PathConstant.ImagePath);
        //MediaNewImage mediaNewImage = _mapper.Map<MediaNewImage>(createMediaNewImageRequest);
        //mediaNewImage.ImagePath = newFolderPath;

        //MediaNewImage addedMediaNewImage = await _mediaNewImageDal.AddAsync(mediaNewImage);
        //CreatedMediaNewImageResponse createdMediaNewImageResponse = _mapper.Map<CreatedMediaNewImageResponse>(addedMediaNewImage);
        //return createdMediaNewImageResponse;
        #endregion

        /* Localhost */

        #region
        string folderPath = currentPath.Replace(currentPath, PathConstant.LocalImagePath);
        string addResult = await _fileHelper.Add(createMediaNewImageRequest.File, folderPath);
        string newFolderPath = addResult.Replace(folderPath, PathConstant.LocalBaseUrlImagePath);

        MediaNewImage mediaNewImage = _mapper.Map<MediaNewImage>(createMediaNewImageRequest);
        mediaNewImage.ImagePath = newFolderPath;

        MediaNewImage addedMediaNewImage = await _mediaNewImageDal.AddAsync(mediaNewImage);
        CreatedMediaNewImageResponse createdMediaNewImageResponse = _mapper.Map<CreatedMediaNewImageResponse>(addedMediaNewImage);
        return createdMediaNewImageResponse;
        #endregion
    }

    public async Task<DeletedMediaNewImageResponse> DeleteAsync(Guid id)
    {
        /* Server */

        #region
        //await _mediaNewImageBusinessRules.IsExistsMediaNewImage(id);
        //MediaNewImage mediaNewImage = await _mediaNewImageDal.GetAsync(predicate: l => l.Id == id);
        //await _fileHelper.Delete(mediaNewImage.ImagePath.TrimStart('\\'));
        //MediaNewImage deletedMediaNewImage = await _mediaNewImageDal.DeleteAsync(mediaNewImage);
        //DeletedMediaNewImageResponse deletedMediaNewImageResponse = _mapper.Map<DeletedMediaNewImageResponse>(deletedMediaNewImage);
        //return deletedMediaNewImageResponse;
        #endregion


        /* Localhost */

        #region
        await _mediaNewImageBusinessRules.IsExistsMediaNewImage(id);
        MediaNewImage mediaNewImage = await _mediaNewImageDal.GetAsync(predicate: l => l.Id == id);
        string imagePath = PathConstant.LocalImagePath + mediaNewImage.ImagePath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
        MediaNewImage deletedMediaNewImage = await _mediaNewImageDal.DeleteAsync(mediaNewImage);
        await _fileHelper.Delete(imagePath);
        DeletedMediaNewImageResponse deletedMediaNewImageResponse = _mapper.Map<DeletedMediaNewImageResponse>(deletedMediaNewImage);
        return deletedMediaNewImageResponse;
        #endregion
    }

    public async Task<GetMediaNewImageResponse> GetByIdAsync(Guid id)
    {
        var mediaNewImage = await _mediaNewImageDal.GetAsync(b => b.Id == id);
        var mappedMediaNewImage = _mapper.Map<GetMediaNewImageResponse>(mediaNewImage);
        return mappedMediaNewImage;
    }

    public async Task<GetMediaNewImageResponse> GetByMediaNewIdAsync(Guid mediaNewId)
    {
        var mediaNewImage = await _mediaNewImageDal.GetAsync(b => b.MediaNewId == mediaNewId);
        var mappedMediaNewImage = _mapper.Map<GetMediaNewImageResponse>(mediaNewImage);
        return mappedMediaNewImage;
    }

    public async Task<IPaginate<GetListMediaNewImageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var mediaNewImages = await _mediaNewImageDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedMediaNewImages = _mapper.Map<Paginate<GetListMediaNewImageResponse>>(mediaNewImages);
        return mappedMediaNewImages;
    }
}

