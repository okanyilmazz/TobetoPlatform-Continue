using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonLikeRequests;
using Business.Dtos.Responses.LessonLikeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class LessonLikeManager : ILessonLikeService
{
    ILessonLikeDal _lessonLikeDal;
    IMapper _mapper;
    LessonLikeBusinessRules _lessonLikeBusinessRules;

    public LessonLikeManager(ILessonLikeDal lessonLikeDal, IMapper mapper, LessonLikeBusinessRules lessonLikeBusinessRules)
    {
        _lessonLikeDal = lessonLikeDal;
        _mapper = mapper;
        _lessonLikeBusinessRules = lessonLikeBusinessRules;
    }

    public async Task<CreatedLessonLikeResponse> AddAsync(CreateLessonLikeRequest createLessonLikeRequest)
    {
        LessonLike lessonLike = _mapper.Map<LessonLike>(createLessonLikeRequest);
        LessonLike createdLessonLike = await _lessonLikeDal.AddAsync(lessonLike);
        CreatedLessonLikeResponse createdLessonLikeResponse = _mapper.Map<CreatedLessonLikeResponse>(createdLessonLike);
        return createdLessonLikeResponse;
    }

    public async Task<DeletedLessonLikeResponse> DeleteAsync(DeleteLessonLikeRequest deleteLessonLikeRequest)
    {
        await _lessonLikeBusinessRules.IsExistsLessonLike(deleteLessonLikeRequest.Id);
        LessonLike lessonLike = await _lessonLikeDal.GetAsync(
            predicate: l => l.Id == deleteLessonLikeRequest.Id);
        LessonLike deletedLessonLike = await _lessonLikeDal.DeleteAsync(lessonLike);
        DeletedLessonLikeResponse deletedLessonLikeResponse = _mapper.Map<DeletedLessonLikeResponse>(deletedLessonLike);
        return deletedLessonLikeResponse;
    }

    public async Task<DeletedLessonLikeResponse> DeleteByAccountIdAndLessonIdAsync(DeleteLessonLikeRequest deleteLessonLikeRequest)
    {
        await _lessonLikeBusinessRules.IsExistsLessonLikeByAccountIdAndLessonId(deleteLessonLikeRequest.AccountId, deleteLessonLikeRequest.LessonId);
        LessonLike lessonLike = await _lessonLikeDal.GetAsync(
        predicate: l => l.AccountId == deleteLessonLikeRequest.AccountId && l.LessonId == deleteLessonLikeRequest.LessonId);
        LessonLike deletedLessonLike = await _lessonLikeDal.DeleteAsync(lessonLike, permanent: true);
        DeletedLessonLikeResponse deletedLessonLikeResponse = _mapper.Map<DeletedLessonLikeResponse>(deletedLessonLike);
        return deletedLessonLikeResponse;
    }

    public async Task<GetListLessonLikeResponse> GetByIdAsync(Guid id)
    {
        var lessonLike = await _lessonLikeDal.GetAsync(
            predicate: l => l.Id == id,
            include: l => l.
            Include(l => l.Lesson).
            Include(l => l.Account));

        var mappedLessonLikes = _mapper.Map<GetListLessonLikeResponse>(lessonLike);
        return mappedLessonLikes;
    }

    public async Task<IPaginate<GetListLessonLikeResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var lessonLike = await _lessonLikeDal.GetListAsync(
            predicate: l => l.AccountId == accountId,
            include: l => l.
            Include(l => l.Lesson).
            Include(l => l.Account));

        var mappedLessonLikes = _mapper.Map<Paginate<GetListLessonLikeResponse>>(lessonLike);
        return mappedLessonLikes;
    }

    public async Task<IPaginate<GetListLessonLikeResponse>> GetByLessonIdAsync(Guid lessonId)
    {
        var lessonLike = await _lessonLikeDal.GetListAsync(
            predicate: l => l.LessonId == lessonId,
            include: l => l.
            Include(l => l.Lesson).
            Include(l => l.Account));

        var mappedLessonLikes = _mapper.Map<Paginate<GetListLessonLikeResponse>>(lessonLike);
        return mappedLessonLikes;
    }

    public async Task<IPaginate<GetListLessonLikeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessonLike = await _lessonLikeDal.GetListAsync(
             include: l => l.
             Include(l => l.Lesson).
             Include(l => l.Account),
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);

        var mappedLessonLikes = _mapper.Map<Paginate<GetListLessonLikeResponse>>(lessonLike);
        return mappedLessonLikes;
    }

    public async Task<UpdatedLessonLikeResponse> UpdateAsync(UpdateLessonLikeRequest updateLessonLikeRequest)
    {
        await _lessonLikeBusinessRules.IsExistsLessonLike(updateLessonLikeRequest.Id);
        LessonLike lessonLike = _mapper.Map<LessonLike>(updateLessonLikeRequest);
        LessonLike updatedLessonLike = await _lessonLikeDal.UpdateAsync(lessonLike);
        UpdatedLessonLikeResponse updatedLessonLikeResponse = _mapper.Map<UpdatedLessonLikeResponse>(updatedLessonLike);
        return updatedLessonLikeResponse;
    }
}
