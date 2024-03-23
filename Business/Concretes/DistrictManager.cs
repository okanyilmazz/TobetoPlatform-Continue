using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.DistrictRequests;
using Business.Dtos.Responses.DistrictResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class DistrictManager : IDistrictService
{
    IDistrictDal _districtDal;
    IMapper _mapper;
    DistrictBusinessRules _districtBusinessRules;

    public DistrictManager(IDistrictDal districtDal, IMapper mapper, DistrictBusinessRules districtBusinessRules)
    {
        _districtDal = districtDal;
        _mapper = mapper;
        _districtBusinessRules = districtBusinessRules;
    }

    public async Task<CreatedDistrictResponse> AddAsync(CreateDistrictRequest createDistrictRequest)
    {
        District district = _mapper.Map<District>(createDistrictRequest);
        District createdDistrict = await _districtDal.AddAsync(district);
        CreatedDistrictResponse createdDistrictResponse = _mapper.Map<CreatedDistrictResponse>(createdDistrict);
        return createdDistrictResponse;

    }

    public async Task<DeletedDistrictResponse> DeleteAsync(Guid id)
    {

        await _districtBusinessRules.IsExistsDistrict(id);
        District district = await _districtDal.GetAsync(predicate: l => l.Id == id);
        District deletedDistrict = await _districtDal.DeleteAsync(district);
        DeletedDistrictResponse deletedDistrictResponse = _mapper.Map<DeletedDistrictResponse>(deletedDistrict);
        return deletedDistrictResponse;
    }

    public async Task<IPaginate<GetListDistrictResponse>> GetByCityIdAsync(Guid cityId)
    {
        var district = await _districtDal.GetListAsync(
            predicate: a => a.CityId == cityId,
            include: d => d
            .Include(d => d.City)
            );
        var mappedDistrict = _mapper.Map<Paginate<GetListDistrictResponse>>(district);
        return mappedDistrict;
    }


    public async Task<GetDistrictResponse> GetByIdAsync(Guid id)
    {
        var district = await _districtDal.GetAsync(
          predicate: d => d.Id == id,
          include: d => d
          .Include(d => d.City));

        var mappedDistricts = _mapper.Map<GetDistrictResponse>(district);
        return mappedDistricts;

    }

    public async Task<IPaginate<GetListDistrictResponse>> GetListAsync(PageRequest pageRequest)
    {
        var district = await _districtDal.GetListAsync(
            include: d => d
            .Include(d => d.City),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);


        var mappedDistricts = _mapper.Map<Paginate<GetListDistrictResponse>>(district);
        return mappedDistricts;
    }

    public async Task<UpdatedDistrictResponse> UpdateAsync(UpdateDistrictRequest updateDistrictRequest)
    {
        await _districtBusinessRules.IsExistsDistrict(updateDistrictRequest.Id);
        District district = _mapper.Map<District>(updateDistrictRequest);
        District updatedDistrict = await _districtDal.UpdateAsync(district);
        UpdatedDistrictResponse updatedDistrictResponse = _mapper.Map<UpdatedDistrictResponse>(updatedDistrict);
        return updatedDistrictResponse;
    }
}
