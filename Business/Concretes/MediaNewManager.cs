using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.MediaNewRequests;
using Business.Dtos.Responses.MediaNewResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class MediaNewManager : IMediaNewService
{
    IMediaNewDal _mediaNewDal;
    IMapper _mapper;
    MediaNewBusinessRules _mediaNewBusinessRules;

    public MediaNewManager(IMediaNewDal mediaNewDal, IMapper mapper, MediaNewBusinessRules mediaNewBusinessRules)
    {
        _mediaNewDal = mediaNewDal;
        _mapper = mapper;
        _mediaNewBusinessRules = mediaNewBusinessRules;
    }

    public async Task<CreatedMediaNewResponse> AddAsync(CreateMediaNewRequest createMediaNewRequest)
    {
        MediaNew mediaNew = _mapper.Map<MediaNew>(createMediaNewRequest);
        MediaNew addedMediaNew = await _mediaNewDal.AddAsync(mediaNew);
        CreatedMediaNewResponse createdMediaNewResponse = _mapper.Map<CreatedMediaNewResponse>(addedMediaNew);
        return createdMediaNewResponse;
    }

    public async Task<DeletedMediaNewResponse> DeleteAsync(Guid id)
    {
        await _mediaNewBusinessRules.IsExistsMediaNew(id);
        MediaNew mediaNew = await _mediaNewDal.GetAsync(predicate: a => a.Id == id);
        MediaNew deletedMediaNew = await _mediaNewDal.DeleteAsync(mediaNew);
        DeletedMediaNewResponse deletedMediaNewResponse = _mapper.Map<DeletedMediaNewResponse>(deletedMediaNew);
        return deletedMediaNewResponse;
    }

    public async Task<GetMediaNewResponse> GetByIdAsync(Guid id)
    {
        var mediaNewId = await _mediaNewDal.GetAsync(m => m.Id == id);
        var mappedMediaNew = _mapper.Map<GetMediaNewResponse>(mediaNewId);
        return mappedMediaNew;
    }

    public async Task<IPaginate<GetListMediaNewResponse>> GetListAsync(PageRequest pageRequest)
    {
        var mediaNew = await _mediaNewDal.GetListAsync(index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedMediaNew = _mapper.Map<Paginate<GetListMediaNewResponse>>(mediaNew);
        return mappedMediaNew;
    }

    public async Task<UpdatedMediaNewResponse> UpdateAsync(UpdateMediaNewRequest updateMediaNewRequest)
    {
        await _mediaNewBusinessRules.IsExistsMediaNew(updateMediaNewRequest.Id);
        MediaNew mediaNew = _mapper.Map<MediaNew>(updateMediaNewRequest);
        MediaNew updatedMediaNew = await _mediaNewDal.UpdateAsync(mediaNew);
        UpdatedMediaNewResponse updatedMediaNewResponse = _mapper.Map<UpdatedMediaNewResponse>(updatedMediaNew);
        return updatedMediaNewResponse;
    }
}