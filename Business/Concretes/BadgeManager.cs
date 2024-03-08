using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.BadgeRequests;
using Business.Dtos.Responses.AccountResponses;
using Business.Dtos.Responses.BadgeResponses;
using Business.Dtos.Responses.LessonResponses;
using Business.Dtos.Responses.SkillResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Business.Concretes;

public class BadgeManager : IBadgeService
{
    IBadgeDal _badgeDal;
    IMapper _mapper;
    BadgeBusinessRules _badgeBusinessRules;
    public BadgeManager(IBadgeDal badgeDal, IMapper mapper, BadgeBusinessRules badgeBusinessRules)
    {
        _badgeDal = badgeDal;
        _mapper = mapper;
        _badgeBusinessRules = badgeBusinessRules;
    }

    public async Task<CreatedBadgeResponse> AddAsync(CreateBadgeRequest createBadgeRequest)
    {
        Badge badge = _mapper.Map<Badge>(createBadgeRequest);
        Badge createdBadge = await _badgeDal.AddAsync(badge);
        CreatedBadgeResponse createdBadgeResponse = _mapper.Map<CreatedBadgeResponse>(createdBadge);
        return createdBadgeResponse;
    }

    public async Task<DeletedBadgeResponse> DeleteAsync(DeleteBadgeRequest deleteBadgeRequest)
    {
        await _badgeBusinessRules.IsExistsBadge(deleteBadgeRequest.Id);
        Badge badge = await _badgeDal.GetAsync(predicate: l => l.Id == deleteBadgeRequest.Id);
        Badge deletedBadge = await _badgeDal.DeleteAsync(badge);
        DeletedBadgeResponse deletedBadgeResponse = _mapper.Map<DeletedBadgeResponse>(deletedBadge);
        return deletedBadgeResponse;
    }
    public async Task<IPaginate<GetListBadgeResponse>> GetByAccountIdAsync(Guid id)
    {
        var badgeList = await _badgeDal.GetListAsync(
            include: b => b.Include(b => b.AccountBadges)
                          .ThenInclude(ab => ab.Account));

        var filteredBadges = badgeList
            .Items.Where(b => b.AccountBadges.Any(ab => ab.AccountId == id)).ToList();

        var mappedBadges = _mapper.Map<Paginate<GetListBadgeResponse>>(filteredBadges);
        return mappedBadges;
        
    }


public async Task<GetListBadgeResponse> GetByIdAsync(Guid Id)
    {
        var badge = await _badgeDal.GetAsync(
            predicate: b => b.Id == Id);
        var mappedBadge = _mapper.Map<GetListBadgeResponse>(badge);
        return mappedBadge;
    }

    public async Task<IPaginate<GetListBadgeResponse>> GetListAsync(PageRequest pageRequest)
    {

        var badges = await _badgeDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedBadges = _mapper.Map<Paginate<GetListBadgeResponse>>(badges);
        return mappedBadges;
    }

    public async Task<UpdatedBadgeResponse> UpdateAsync(UpdateBadgeRequest updateBadgeRequest)
    {
        await _badgeBusinessRules.IsExistsBadge(updateBadgeRequest.Id);
        Badge badge = _mapper.Map<Badge>(updateBadgeRequest);
        Badge updatedBadge = await _badgeDal.UpdateAsync(badge);
        UpdatedBadgeResponse updatedBadgeResponse = _mapper.Map<UpdatedBadgeResponse>(updatedBadge);
        return updatedBadgeResponse;
    }
}