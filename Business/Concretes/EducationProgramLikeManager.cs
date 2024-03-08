using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Dtos.Responses.EducationProgramLikeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramLikeManager : IEducationProgramLikeService
{
    IEducationProgramLikeDal _educationProgramLikeDal;
    IMapper _mapper;
    EducationProgramLikeBusinessRules _educationProgramLikeBusinessRules;

    public EducationProgramLikeManager(IEducationProgramLikeDal educationProgramLikeDal, IMapper mapper, EducationProgramLikeBusinessRules educationProgramLikeBusinessRules)
    {
        _educationProgramLikeDal = educationProgramLikeDal;
        _mapper = mapper;
        _educationProgramLikeBusinessRules = educationProgramLikeBusinessRules;
    }

    public async Task<CreatedEducationProgramLikeResponse> AddAsync(CreateEducationProgramLikeRequest createEducationProgramLikeRequest)
    {
        EducationProgramLike educationProgramLike = _mapper.Map<EducationProgramLike>(createEducationProgramLikeRequest);
        EducationProgramLike createdEducationProgramLike = await _educationProgramLikeDal.AddAsync(educationProgramLike);
        CreatedEducationProgramLikeResponse createdEducationProgramLikeResponse = _mapper.Map<CreatedEducationProgramLikeResponse>(createdEducationProgramLike);
        return createdEducationProgramLikeResponse;
    }

    public async Task<DeletedEducationProgramLikeResponse> DeleteAsync(DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest)
    {
        await _educationProgramLikeBusinessRules.IsExistsEducationProgramLike(deleteEducationProgramLikeRequest.Id);
        EducationProgramLike educationProgramLike = await _educationProgramLikeDal.GetAsync(
            predicate: l => l.Id == deleteEducationProgramLikeRequest.Id);
        EducationProgramLike deletedEducationProgramLike = await _educationProgramLikeDal.DeleteAsync(educationProgramLike);
        DeletedEducationProgramLikeResponse deletedEducationProgramLikeResponse = _mapper.Map<DeletedEducationProgramLikeResponse>(deletedEducationProgramLike);
        return deletedEducationProgramLikeResponse;
    }

    public async Task<DeletedEducationProgramLikeResponse> DeleteByAccountIdAndEducationProgramIdAsync(DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest)
    {
        await _educationProgramLikeBusinessRules.IsExistsEducationProgramLikeByAccountIdAndEducationProgramId(deleteEducationProgramLikeRequest.AccountId, deleteEducationProgramLikeRequest.EducationProgramId);
        EducationProgramLike educationProgramLike = await _educationProgramLikeDal.GetAsync(
        predicate: epl => epl.AccountId == deleteEducationProgramLikeRequest.AccountId && epl.EducationProgramId == deleteEducationProgramLikeRequest.EducationProgramId);
        EducationProgramLike deletedEducationProgramLike = await _educationProgramLikeDal.DeleteAsync(educationProgramLike, permanent: true);
        DeletedEducationProgramLikeResponse deletedEducationProgramLikeResponse = _mapper.Map<DeletedEducationProgramLikeResponse>(deletedEducationProgramLike);
        return deletedEducationProgramLikeResponse;
    }

    public async Task<GetEducationProgramLikeResponse> GetByIdAsync(Guid id)
    {
        var educationProgramLike = await _educationProgramLikeDal.GetAsync(
            predicate: l => l.Id == id,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Account));

        var mappedEducationProgramLike = _mapper.Map<GetEducationProgramLikeResponse>(educationProgramLike);
        return mappedEducationProgramLike;
    }

    public async Task<IPaginate<GetListEducationProgramLikeResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var educationProgramLike = await _educationProgramLikeDal.GetListAsync(
            predicate: l => l.AccountId == accountId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Account));

        var mappedEducationProgramLikes = _mapper.Map<Paginate<GetListEducationProgramLikeResponse>>(educationProgramLike);
        return mappedEducationProgramLikes;
    }

    public async Task<IPaginate<GetListEducationProgramLikeResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var educationProgramLike = await _educationProgramLikeDal.GetListAsync(
            predicate: l => l.EducationProgramId == educationProgramId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Account));

        var mappedEducationProgramLikes = _mapper.Map<Paginate<GetListEducationProgramLikeResponse>>(educationProgramLike);
        return mappedEducationProgramLikes;
    }

    public async Task<GetEducationProgramLikeResponse> GetByEducationProgramIdAndAccountIdAsync(Guid educationProgramId, Guid accountId)
    {
        var educationProgramLike = await _educationProgramLikeDal.GetAsync(
            predicate: l => l.EducationProgramId == educationProgramId && l.AccountId == accountId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Account));

        var mappedEducationProgramLike = _mapper.Map<GetEducationProgramLikeResponse>(educationProgramLike);
        return mappedEducationProgramLike;
    }


    public async Task<IPaginate<GetListEducationProgramLikeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var educationProgramLike = await _educationProgramLikeDal.GetListAsync(
             include: l => l.
             Include(l => l.EducationProgram).
             Include(l => l.Account),
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);

        var mappedEducationProgramLikes = _mapper.Map<Paginate<GetListEducationProgramLikeResponse>>(educationProgramLike);
        return mappedEducationProgramLikes;
    }

    public async Task<UpdatedEducationProgramLikeResponse> UpdateAsync(UpdateEducationProgramLikeRequest updateEducationProgramLikeRequest)
    {
        await _educationProgramLikeBusinessRules.IsExistsEducationProgramLike(updateEducationProgramLikeRequest.Id);
        EducationProgramLike educationProgramLike = _mapper.Map<EducationProgramLike>(updateEducationProgramLikeRequest);
        EducationProgramLike updatedEducationProgramLike = await _educationProgramLikeDal.UpdateAsync(educationProgramLike);
        UpdatedEducationProgramLikeResponse updatedEducationProgramLikeResponse = _mapper.Map<UpdatedEducationProgramLikeResponse>(updatedEducationProgramLike);
        return updatedEducationProgramLikeResponse;
    }
}
