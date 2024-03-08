using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AnnouncementReadRequests;
using Business.Dtos.Responses.AnnouncementReadResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AnnouncementReadManager : IAnnouncementReadService
{
    IAnnouncementReadDal _announcementReadDal;
    IMapper _mapper;
    AnnouncementReadBusinessRules _announcementReadBusinessRules;
    public AnnouncementReadManager(IAnnouncementReadDal announcementReadDal, IMapper mapper, AnnouncementReadBusinessRules announcementReadBusinessRules)
    {
        _announcementReadDal = announcementReadDal;
        _mapper = mapper;
        _announcementReadBusinessRules = announcementReadBusinessRules;
    }

    public async Task<CreatedAnnouncementReadResponse> AddAsync(CreateAnnouncementReadRequest createAnnouncementReadRequest)
    {
        AnnouncementRead announcementRead = _mapper.Map<AnnouncementRead>(createAnnouncementReadRequest);
        AnnouncementRead createdAnnouncementRead = await _announcementReadDal.AddAsync(announcementRead);
        CreatedAnnouncementReadResponse createdAnnouncementReadResponse = _mapper.Map<CreatedAnnouncementReadResponse>(createdAnnouncementRead);
        return createdAnnouncementReadResponse; ;
    }

    public async Task<DeletedAnnouncementReadResponse> DeleteAsync(DeleteAnnouncementReadRequest deleteAnnouncementReadRequest)
    {
        await _announcementReadBusinessRules.IsExistsAnnouncementRead(deleteAnnouncementReadRequest.Id);

        AnnouncementRead announcementRead = await _announcementReadDal.GetAsync(predicate: at => at.Id == deleteAnnouncementReadRequest.Id);
        AnnouncementRead deletedAnnouncementRead = await _announcementReadDal.DeleteAsync(announcementRead);
        DeletedAnnouncementReadResponse deletedAnnouncementReadResponse = _mapper.Map<DeletedAnnouncementReadResponse>(deletedAnnouncementRead);
        return deletedAnnouncementReadResponse;
    }

    public async Task<IPaginate<GetListAnnouncementReadResponse>> GetByAccountIdAsync(Guid accountId)
    {

        var announcementRead = await _announcementReadDal.GetListAsync(
            predicate: ar => ar.AccountId == accountId,
            include: ar => ar.
            Include(l => l.Announcement)
            .Include(l => l.Account));

        var mappedAnnouncementRead = _mapper.Map<Paginate<GetListAnnouncementReadResponse>>(announcementRead);
        return mappedAnnouncementRead;
    }

    public async Task<IPaginate<GetListAnnouncementReadResponse>> GetByAnnouncementIdAsync(Guid announcementId)
    {
        var announcementRead = await _announcementReadDal.GetListAsync(
           predicate: ar => ar.AnnouncementId == announcementId,
           include: ar => ar.
           Include(l => l.Announcement)
           .Include(l => l.Account));

        var mappedAnnouncementRead = _mapper.Map<Paginate<GetListAnnouncementReadResponse>>(announcementRead);
        return mappedAnnouncementRead;
    }

    public async Task<GetAnnouncementReadResponse> GetByIdAsync(Guid Id)
    {
        var announcementRead = await _announcementReadDal.GetAsync(
            predicate: at => at.Id == Id,
              include: ar => ar.
            Include(l => l.Announcement)
            .Include(l => l.Account));

        var mappedAnnouncementRead = _mapper.Map<GetAnnouncementReadResponse>(announcementRead);
        return mappedAnnouncementRead;
    }

    public async Task<IPaginate<GetListAnnouncementReadResponse>> GetListAsync(PageRequest pageRequest)
    {
        var announcementReads = await _announcementReadDal.GetListAsync(
              include: ar => ar
              .Include(l => l.Announcement)
              .Include(l => l.Account),
              index: pageRequest.PageIndex,
              size: pageRequest.PageSize);
        var mappedAnnouncementRead = _mapper.Map<Paginate<GetListAnnouncementReadResponse>>(announcementReads);
        return mappedAnnouncementRead;
    }

    public async Task<UpdatedAnnouncementReadResponse> UpdateAsync(UpdateAnnouncementReadRequest updateAnnouncementReadRequest)
    {
        await _announcementReadBusinessRules.IsExistsAnnouncementRead(updateAnnouncementReadRequest.Id);
        AnnouncementRead announcementRead = _mapper.Map<AnnouncementRead>(updateAnnouncementReadRequest);
        AnnouncementRead updatedAnnouncementRead = await _announcementReadDal.UpdateAsync(announcementRead);
        UpdatedAnnouncementReadResponse updatedAnnouncementReadResponse = _mapper.Map<UpdatedAnnouncementReadResponse>(updatedAnnouncementRead);
        return updatedAnnouncementReadResponse;
    }
}
