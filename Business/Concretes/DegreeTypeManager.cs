using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.DegreeTypeRequests;
using Business.Dtos.Responses.DegreeTypeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class DegreeTypeManager : IDegreeTypeService
{
    IDegreeTypeDal _degreeTypeDal;
    IMapper _mapper;
    DegreeTypeBusinessRules _degreeTypeBusinessRules;

    public DegreeTypeManager(IDegreeTypeDal degreeTypeDal, IMapper mapper, DegreeTypeBusinessRules degreeTypeBusinessRules)
    {
        _degreeTypeDal = degreeTypeDal;
        _mapper = mapper;
        _degreeTypeBusinessRules = degreeTypeBusinessRules;
    }

    public async Task<CreatedDegreeTypeResponse> AddAsync(CreateDegreeTypeRequest createDegreeTypeRequest)
    {
        DegreeType degreeType = _mapper.Map<DegreeType>(createDegreeTypeRequest);
        DegreeType addeddegreeType = await _degreeTypeDal.AddAsync(degreeType);
        CreatedDegreeTypeResponse createddegreeTypeResponse =
        _mapper.Map<CreatedDegreeTypeResponse>(addeddegreeType);
        return createddegreeTypeResponse;
    }

    public async Task<DeletedDegreeTypeResponse> DeleteAsync(Guid id)
    {
        await _degreeTypeBusinessRules.IsExistsDegreeType(id);
        DegreeType degreeType = await _degreeTypeDal.GetAsync(predicate: d => d.Id == id);
        DegreeType deleteddegreeType = await _degreeTypeDal.DeleteAsync(degreeType);
        DeletedDegreeTypeResponse deleteddegreeTypeResponse =
        _mapper.Map<DeletedDegreeTypeResponse>(deleteddegreeType);
        return deleteddegreeTypeResponse;
    }

    public async Task<GetDegreeTypeResponse> GetByIdAsync(Guid id)
    {
        var degreeType = await _degreeTypeDal.GetAsync(d => d.Id == id);
        var mappeddegreeType = _mapper.Map<GetDegreeTypeResponse>(degreeType);
        return mappeddegreeType;
    }

    public async Task<IPaginate<GetListDegreeTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var degreeTypes = await _degreeTypeDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappeddegreeTypes = _mapper.Map<Paginate<GetListDegreeTypeResponse>>(degreeTypes);
        return mappeddegreeTypes;
    }

    public async Task<UpdatedDegreeTypeResponse> UpdateAsync(UpdateDegreeTypeRequest updatedegreeTypeRequest)
    {
        await _degreeTypeBusinessRules.IsExistsDegreeType(updatedegreeTypeRequest.Id);
        DegreeType degreeType = _mapper.Map<DegreeType>(updatedegreeTypeRequest);
        DegreeType updateddegreeType = await _degreeTypeDal.UpdateAsync(degreeType);
        UpdatedDegreeTypeResponse updateddegreeTypeResponse = _mapper.Map<UpdatedDegreeTypeResponse>
        (updateddegreeType);
        return updateddegreeTypeResponse;
    }
}

