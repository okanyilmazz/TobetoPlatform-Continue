using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramOccupationClassRequests;
using Business.Dtos.Responses.EducationProgramOccupationClassResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramOccupationClassManager : IEducationProgramOccupationClassService
{

    IEducationProgramOccupationClassDal _educationProgramOccupationClassDal;
    IMapper _mapper;
    EducationProgramOccupationClassBusinessRules _educationProgramOccupationClassBusinessRules;

    public EducationProgramOccupationClassManager(IEducationProgramOccupationClassDal educationProgramOccupationClassDal, IMapper mapper, EducationProgramOccupationClassBusinessRules educationProgramOccupationClassBusinessRules)
    {
        _educationProgramOccupationClassDal = educationProgramOccupationClassDal;
        _mapper = mapper;
        _educationProgramOccupationClassBusinessRules = educationProgramOccupationClassBusinessRules;
    }

    public async Task<CreatedEducationProgramOccupationClassResponse> AddAsync(CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest)
    {
        EducationProgramOccupationClass EducationProgramOccupationClass = _mapper.Map<EducationProgramOccupationClass>(createEducationProgramOccupationClassRequest);
        EducationProgramOccupationClass createdEducationProgramOccupationClass = await _educationProgramOccupationClassDal.AddAsync(EducationProgramOccupationClass);
        CreatedEducationProgramOccupationClassResponse createdEducationProgramOccupationClassResponse = _mapper.Map<CreatedEducationProgramOccupationClassResponse>(createdEducationProgramOccupationClass);
        return createdEducationProgramOccupationClassResponse;
    }

    public async Task<DeletedEducationProgramOccupationClassResponse> DeleteAsync(DeleteEducationProgramOccupationClassRequest deleteEducationProgramOccupationClassRequest)
    {
        await _educationProgramOccupationClassBusinessRules.IsExistsEducationProgramOccupationClass(deleteEducationProgramOccupationClassRequest.Id);
        EducationProgramOccupationClass educationProgramOccupationClass = await _educationProgramOccupationClassDal.GetAsync(predicate: e => e.Id == deleteEducationProgramOccupationClassRequest.Id);
        EducationProgramOccupationClass deletedEducationProgramOccupationClass = await _educationProgramOccupationClassDal.DeleteAsync(educationProgramOccupationClass);
        DeletedEducationProgramOccupationClassResponse deletedEducationProgramOccupationClassResponse = _mapper.Map<DeletedEducationProgramOccupationClassResponse>(deletedEducationProgramOccupationClass);
        return deletedEducationProgramOccupationClassResponse;
    }

    public async Task<GetListEducationProgramOccupationClassResponse> GetByIdAsync(Guid id)
    {
        var educationProgramOccupationClass = await _educationProgramOccupationClassDal.GetAsync(
            predicate: h => h.Id == id,
            include: epoc => epoc
            .Include(epoc => epoc.OccupationClass)
            .Include(epoc => epoc.EducationProgram));
        return _mapper.Map<GetListEducationProgramOccupationClassResponse>(educationProgramOccupationClass);
    }

    public async Task<IPaginate<GetListEducationProgramOccupationClassResponse>> GetListAsync(PageRequest pageRequest)
    {
        var EducationProgramOccupationClasss = await _educationProgramOccupationClassDal.GetListAsync(
            index:pageRequest.PageIndex,
            size:pageRequest.PageSize,
            include: epoc => epoc
            .Include(epoc => epoc.OccupationClass)
            .Include(epoc => epoc.EducationProgram)

            );
        var mappedEducationProgramOccupationClasses = _mapper.Map<Paginate<GetListEducationProgramOccupationClassResponse>>(EducationProgramOccupationClasss);
        return mappedEducationProgramOccupationClasses;
    }

    public async Task<UpdatedEducationProgramOccupationClassResponse> UpdateAsync(UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest)
    {
        await _educationProgramOccupationClassBusinessRules.IsExistsEducationProgramOccupationClass(updateEducationProgramOccupationClassRequest.Id);
        EducationProgramOccupationClass EducationProgramOccupationClass = _mapper.Map<EducationProgramOccupationClass>(updateEducationProgramOccupationClassRequest);
        EducationProgramOccupationClass updatedEducationProgramOccupationClass = await _educationProgramOccupationClassDal.UpdateAsync(EducationProgramOccupationClass);
        UpdatedEducationProgramOccupationClassResponse updatedEducationProgramOccupationClassResponse = _mapper.Map<UpdatedEducationProgramOccupationClassResponse>(updatedEducationProgramOccupationClass);
        return updatedEducationProgramOccupationClassResponse;
    }
}
