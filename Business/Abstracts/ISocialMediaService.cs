﻿using Business.Dtos.Requests.SocialMediaRequests;
using Business.Dtos.Responses.SocialMediaResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISocialMediaService
{
    Task<IPaginate<GetListSocialMediaResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListSocialMediaResponse>> GetByAccountIdAsync(Guid Id);
    Task<GetSocialMediaResponse> GetByIdAsync(Guid id);
    Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest);
    Task<DeletedSocialMediaResponse> DeleteAsync(Guid id);
    Task<UpdatedSocialMediaResponse> UpdateAsync(UpdateSocialMediaRequest updateSocialMediaRequest);
}

