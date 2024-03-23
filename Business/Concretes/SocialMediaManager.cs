using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SocialMediaRequests;
using Business.Dtos.Responses.SocialMediaResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SocialMediaManager : ISocialMediaService
{
    ISocialMediaDal _socialMediaDal;
    IMapper _mapper;
    SocialMediaBusinessRules _socialMediaBusinessRules;

    public SocialMediaManager(ISocialMediaDal socialMediaDal, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
    {
        _socialMediaDal = socialMediaDal;
        _mapper = mapper;
        _socialMediaBusinessRules = socialMediaBusinessRules;
    }

    public async Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest)
    {
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(createSocialMediaRequest);
        SocialMedia addedSocialMedia = await _socialMediaDal.AddAsync(socialMedia);
        CreatedSocialMediaResponse createdSocialMediaResponse = _mapper.Map<CreatedSocialMediaResponse>(addedSocialMedia);
        return createdSocialMediaResponse;
    }

    public async Task<DeletedSocialMediaResponse> DeleteAsync(Guid id)
    {
        await _socialMediaBusinessRules.IsExistsSocialMedia(id);
        SocialMedia socialMedia = await _socialMediaDal.GetAsync(predicate: s => s.Id == id);
        SocialMedia deletedSocialMedia = await _socialMediaDal.DeleteAsync(socialMedia);
        DeletedSocialMediaResponse deletedSocialMediaResponse = _mapper.Map<DeletedSocialMediaResponse>(deletedSocialMedia);
        return deletedSocialMediaResponse;
    }

    public async Task<IPaginate<GetListSocialMediaResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var socialMediaList = await _socialMediaDal.GetListAsync(
            include: s => s.Include(a => a.AccountSocialMedias).ThenInclude(asm => asm.Account));
        var filteredSocialMedias = socialMediaList
            .Items.Where(e => e.AccountSocialMedias.Any(s => s.AccountId == accountId)).ToList();
        var mappedSocialMedias = _mapper.Map<Paginate<GetListSocialMediaResponse>>(filteredSocialMedias);
        return mappedSocialMedias;
    }

    public async Task<GetSocialMediaResponse> GetByIdAsync(Guid id)
    {
        var socialMedia = await _socialMediaDal.GetAsync(s => s.Id == id);
        var mappedSocialMedia = _mapper.Map<GetSocialMediaResponse>(socialMedia);
        return mappedSocialMedia;
    }

    public async Task<IPaginate<GetListSocialMediaResponse>> GetListAsync(PageRequest pageRequest)
    {
        var socialMedias = await _socialMediaDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedSocialMedias = _mapper.Map<Paginate<GetListSocialMediaResponse>>(socialMedias);
        return mappedSocialMedias;
    }

    public async Task<UpdatedSocialMediaResponse> UpdateAsync(UpdateSocialMediaRequest updateSocialMediaRequest)
    {
        await _socialMediaBusinessRules.IsExistsSocialMedia(updateSocialMediaRequest.Id);
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaRequest);
        SocialMedia updatedSocialMedia = await _socialMediaDal.UpdateAsync(socialMedia);
        UpdatedSocialMediaResponse updatedSocialMediaResponse = _mapper.Map<UpdatedSocialMediaResponse>(updatedSocialMedia);
        return updatedSocialMediaResponse;
    }
}

