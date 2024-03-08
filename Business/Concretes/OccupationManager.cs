using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.OccupationRequests;
using Business.Dtos.Responses.OccupationResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class OccupationManager : IOccupationService
{
    IOccupationDal _occupationDal;
    IMapper _mapper;
    OccupationBusinessRules _occupationBusinessRules;

    public OccupationManager(IOccupationDal occupationDal, IMapper mapper, OccupationBusinessRules occupationBusinessRules)
    {
        _occupationDal = occupationDal;
        _mapper = mapper;
        _occupationBusinessRules = occupationBusinessRules;
    }

    public async Task<CreatedOccupationResponse> AddAsync(CreateOccupationRequest createOccupationRequest)
    {
        Occupation occupation = _mapper.Map<Occupation>(createOccupationRequest);
        Occupation addedOccupation = await _occupationDal.AddAsync(occupation);
        CreatedOccupationResponse createdOccupationResponse = _mapper.Map<CreatedOccupationResponse>(addedOccupation);
        return createdOccupationResponse;
    }

    public async Task<DeletedOccupationResponse> DeleteAsync(DeleteOccupationRequest deleteOccupationRequest)
    {
        await _occupationBusinessRules.IsExistsOccupation(deleteOccupationRequest.Id);
        Occupation occupation = await _occupationDal.GetAsync(predicate: c => c.Id == deleteOccupationRequest.Id);
        Occupation deletedOccupation = await _occupationDal.DeleteAsync(occupation);
        DeletedOccupationResponse deletedOccupationResponse = _mapper.Map<DeletedOccupationResponse>(deletedOccupation);
        return deletedOccupationResponse;
    }

    public async Task<GetListOccupationResponse> GetByIdAsync(Guid id)
    {
        var Occupation = await _occupationDal.GetAsync(p => p.Id == id);
        var mappedOccupation = _mapper.Map<GetListOccupationResponse>(Occupation);
        return mappedOccupation;
    }

    public async Task<IPaginate<GetListOccupationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var Occupation = await _occupationDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedOccupation = _mapper.Map<Paginate<GetListOccupationResponse>>(Occupation);
        return mappedOccupation;
    }

    public async Task<UpdatedOccupationResponse> UpdateAsync(UpdateOccupationRequest updateOccupationRequest)
    {
        await _occupationBusinessRules.IsExistsOccupation(updateOccupationRequest.Id);
        Occupation occupation = _mapper.Map<Occupation>(updateOccupationRequest);
        Occupation updatedOccupation = await _occupationDal.UpdateAsync(occupation);
        UpdatedOccupationResponse updatedOccupationResponse = _mapper.Map<UpdatedOccupationResponse>(updatedOccupation);
        return updatedOccupationResponse;
    }
}
