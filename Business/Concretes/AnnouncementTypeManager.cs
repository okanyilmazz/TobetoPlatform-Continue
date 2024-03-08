using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AnnouncementTypeRequests;
using Business.Dtos.Responses.AnnouncementTypeResponse;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class AnnouncementTypeManager : IAnnouncementTypeService
{
    IAnnouncementTypeDal _announcementTypeDal;
    IMapper _mapper;
    AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

    public AnnouncementTypeManager(IAnnouncementTypeDal announcementTypeDal, IMapper mapper, AnnouncementTypeBusinessRules announcementTypeBusinessRules)
    {
        _announcementTypeDal = announcementTypeDal;
        _mapper = mapper;
        _announcementTypeBusinessRules = announcementTypeBusinessRules;
    }

    public async Task<CreatedAnnouncementTypeResponse> AddAsync(CreateAnnouncementTypeRequest createAnnouncementTypeRequest)
    {
        AnnouncementType announcementType = _mapper.Map<AnnouncementType>(createAnnouncementTypeRequest);
        AnnouncementType createdAnnouncementType = await _announcementTypeDal.AddAsync(announcementType);
        CreatedAnnouncementTypeResponse createdAnnouncementTypeResponse = _mapper.Map<CreatedAnnouncementTypeResponse>(createdAnnouncementType);
        return createdAnnouncementTypeResponse;
    }

    public async Task<DeletedAnnouncementTypeResponse> DeleteAsync(DeleteAnnouncementTypeRequest deleteAnnouncementTypeRequest)
    {
        await _announcementTypeBusinessRules.IsExistsAnnouncementType(deleteAnnouncementTypeRequest.Id);

        AnnouncementType announcementType = await _announcementTypeDal.GetAsync(predicate: at => at.Id == deleteAnnouncementTypeRequest.Id);
        AnnouncementType deletedAnnouncementType = await _announcementTypeDal.DeleteAsync(announcementType);
        DeletedAnnouncementTypeResponse deletedAnnouncementTypeResponse = _mapper.Map<DeletedAnnouncementTypeResponse>(deletedAnnouncementType);
        return deletedAnnouncementTypeResponse;
    }

    public async Task<GetListAnnouncementTypeResponse> GetByIdAsync(Guid Id)
    {
        var announcementType = await _announcementTypeDal.GetAsync(at => at.Id == Id);
        var mappedAnnouncementType = _mapper.Map<GetListAnnouncementTypeResponse>(announcementType);
        return mappedAnnouncementType;
    }

    public async Task<IPaginate<GetListAnnouncementTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var announcementTypes = await _announcementTypeDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedAnnouncementType = _mapper.Map<Paginate<GetListAnnouncementTypeResponse>>(announcementTypes);
        return mappedAnnouncementType;
    }

    public async Task<UpdatedAnnouncementTypeResponse> UpdateAsync(UpdateAnnouncementTypeRequest updateAnnouncementTypeRequest)
    {
        await _announcementTypeBusinessRules.IsExistsAnnouncementType(updateAnnouncementTypeRequest.Id);
        AnnouncementType announcementType = _mapper.Map<AnnouncementType>(updateAnnouncementTypeRequest);
        AnnouncementType updatedAnnouncementType = await _announcementTypeDal.UpdateAsync(announcementType);
        UpdatedAnnouncementTypeResponse updatedAnnouncementTypeResponse = _mapper.Map<UpdatedAnnouncementTypeResponse>(updatedAnnouncementType);
        return updatedAnnouncementTypeResponse;
    }
}
