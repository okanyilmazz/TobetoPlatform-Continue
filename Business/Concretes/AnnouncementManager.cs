using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AnnouncementRequests;
using Business.Dtos.Responses.AnnouncementResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AnnouncementManager : IAnnouncementService
{
    IAnnouncementDal _announcementDal;
    IMapper _mapper;
    AnnouncementBusinessRules _announcementBusinessRules;

    public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper, AnnouncementBusinessRules announcementBusinessRules)
    {
        _announcementDal = announcementDal;
        _mapper = mapper;
        _announcementBusinessRules = announcementBusinessRules;
    }

    public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
    {
        Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        Announcement addedAnnouncement = await _announcementDal.AddAsync(announcement);
        CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(addedAnnouncement);
        return createdAnnouncementResponse;

    }

    public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        await _announcementBusinessRules.IsExistsAnnouncement(deleteAnnouncementRequest.Id);
        Announcement announcement = await _announcementDal.GetAsync(predicate: a => a.Id == deleteAnnouncementRequest.Id);
        Announcement deletedAnnouncemenProject = await _announcementDal.DeleteAsync(announcement);
        DeletedAnnouncementResponse deletedAnnouncementResponse = _mapper.Map<DeletedAnnouncementResponse>(deletedAnnouncemenProject);
        return deletedAnnouncementResponse;
    }

    public async Task<GetListAnnouncementResponse> GetByIdAsync(Guid Id)
    {
        var announcement = await _announcementDal.GetAsync(
            predicate: a => a.Id == Id,
            include: a => a.Include(a => a.AnnouncementType));

        var mappedAnnouncement = _mapper.Map<GetListAnnouncementResponse>(announcement);
        return mappedAnnouncement;
    }

    public async Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
    {
        var announcement = await _announcementDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize,
            include: a => a.Include(a => a.AnnouncementType));
        var mappedAnnouncement = _mapper.Map<Paginate<GetListAnnouncementResponse>>(announcement);
        return mappedAnnouncement;
    }

    public async Task<IPaginate<GetListAnnouncementResponse>> GetWithProjectListAsync(PageRequest pageRequest)
    {
        var announcement = await _announcementDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedAnnouncement = _mapper.Map<Paginate<GetListAnnouncementResponse>>(announcement);
        return mappedAnnouncement;
    }

    public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        await _announcementBusinessRules.IsExistsAnnouncement(updateAnnouncementRequest.Id);
        Announcement announcement = _mapper.Map<Announcement>(updateAnnouncementRequest);
        Announcement updatedAnnouncemenProject = await _announcementDal.UpdateAsync(announcement);
        UpdatedAnnouncementResponse updatedAnnouncementResponse = _mapper.Map<UpdatedAnnouncementResponse>(updatedAnnouncemenProject);
        return updatedAnnouncementResponse;
    }
}

