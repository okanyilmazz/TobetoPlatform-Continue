using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.UniversityDepartmentRequests;
using Business.Dtos.Responses.UniversityDepartmentResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class UniversityDepartmentManager : IUniversityDepartmentService
{
    IUniversityDepartmentDal _universityDepartmentDal;
    IMapper _mapper;
    UniversityDepartmentBusinessRules _universityDepartmentRules;

    public UniversityDepartmentManager(IUniversityDepartmentDal universityDepartmentDal, IMapper mapper, UniversityDepartmentBusinessRules universityDepartmentRules)
    {
        _universityDepartmentDal = universityDepartmentDal;
        _mapper = mapper;
        _universityDepartmentRules = universityDepartmentRules;
    }

    public async Task<CreatedUniversityDepartmentResponse> AddAsync(CreateUniversityDepartmentRequest createUniversityDepartmentRequest)
    {
        UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(createUniversityDepartmentRequest);
        UniversityDepartment addedUniversityDepartment = await _universityDepartmentDal.AddAsync(universityDepartment);
        CreatedUniversityDepartmentResponse createdUniversityDepartmentResponse = _mapper.Map<CreatedUniversityDepartmentResponse>(addedUniversityDepartment);
        return createdUniversityDepartmentResponse;
    }

    public async Task<DeletedUniversityDepartmentResponse> DeleteAsync(DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest)
    {
        await _universityDepartmentRules.IsExistsUniversityDepartment(deleteUniversityDepartmentRequest.Id);
        UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(deleteUniversityDepartmentRequest);
        UniversityDepartment deletedUniversityDepartment = await _universityDepartmentDal.DeleteAsync(universityDepartment);
        DeletedUniversityDepartmentResponse deletedUniversityDepartmentResponse = _mapper.Map<DeletedUniversityDepartmentResponse>(deletedUniversityDepartment);
        return deletedUniversityDepartmentResponse;
    }

    public async Task<GetListUniversityDepartmentResponse> GetByIdAsync(Guid id)
    {
        var universityDepartment = await _universityDepartmentDal.GetAsync(ud => ud.Id == id);
        var mappedUniversityDepartment = _mapper.Map<GetListUniversityDepartmentResponse>(universityDepartment);
        return mappedUniversityDepartment;
    }

    public async Task<IPaginate<GetListUniversityDepartmentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var universityDepartment = await _universityDepartmentDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedUniversityDepartment = _mapper.Map<Paginate<GetListUniversityDepartmentResponse>>(universityDepartment);
        return mappedUniversityDepartment;
    }

    public async Task<UpdatedUniversityDepartmentResponse> UpdateAsync(UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest)
    {
        await _universityDepartmentRules.IsExistsUniversityDepartment(updateUniversityDepartmentRequest.Id);
        UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(updateUniversityDepartmentRequest);
        UniversityDepartment updatedUniversityDepartment = await _universityDepartmentDal.UpdateAsync(universityDepartment);
        UpdatedUniversityDepartmentResponse updatedUniversityDepartmentResponse = _mapper.Map<UpdatedUniversityDepartmentResponse>(updatedUniversityDepartment);
        return updatedUniversityDepartmentResponse;
    }
}