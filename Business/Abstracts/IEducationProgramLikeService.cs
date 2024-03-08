﻿using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Dtos.Responses.EducationProgramLikeResponses;
using Business.Dtos.Responses.LessonLikeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramLikeService
{
    Task<CreatedEducationProgramLikeResponse> AddAsync(CreateEducationProgramLikeRequest createEducationProgramLikeRequest);
    Task<UpdatedEducationProgramLikeResponse> UpdateAsync(UpdateEducationProgramLikeRequest updateEducationProgramLikeRequest);
    Task<DeletedEducationProgramLikeResponse> DeleteAsync(DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListEducationProgramLikeResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
    Task<DeletedEducationProgramLikeResponse> DeleteByAccountIdAndEducationProgramIdAsync(DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest);
}