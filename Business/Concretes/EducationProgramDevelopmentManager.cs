using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using Business.Dtos.Responses.EducationProgramDevelopmentResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class EducationProgramDevelopmentManager : IEducationProgramDevelopmentService
{
    IEducationProgramDevelopmentDal _educationProgramDevelopmentDal;
    IMapper _mapper;
    EducationProgramDevelopmentBusinessRules _educationProgramDevelopmentBusinesRules;

    public EducationProgramDevelopmentManager(IEducationProgramDevelopmentDal educationProgramDevelopmentDal, IMapper mapper, EducationProgramDevelopmentBusinessRules educationProgramDevelopmentBusinesRules)
    {
        _educationProgramDevelopmentDal = educationProgramDevelopmentDal;
        _mapper = mapper;
        _educationProgramDevelopmentBusinesRules = educationProgramDevelopmentBusinesRules;
    }

    public async Task<CreatedEducationProgramDevelopmentResponse> AddAsync(CreateEducationProgramDevelopmentRequest createEducationProgramDevelopmentRequest)
    {
        EducationProgramDevelopment educationProgramDevelopment = _mapper.Map<EducationProgramDevelopment>(createEducationProgramDevelopmentRequest);
        EducationProgramDevelopment addedEducationProgramDevelopment = await _educationProgramDevelopmentDal.AddAsync(educationProgramDevelopment);
        CreatedEducationProgramDevelopmentResponse createdEducationProgramDevelopmentResponse = _mapper.Map<CreatedEducationProgramDevelopmentResponse>(addedEducationProgramDevelopment);
        return createdEducationProgramDevelopmentResponse;
    }

    public async Task<DeletedEducationProgramDevelopmentResponse> DeleteAsync(DeleteEducationProgramDevelopmentRequest deleteEducationProgramDevelopmentRequest)
    {
        await _educationProgramDevelopmentBusinesRules.IsExistsEducationProgramDevelopment(deleteEducationProgramDevelopmentRequest.Id);
        EducationProgramDevelopment educationProgramDevelopment = await _educationProgramDevelopmentDal.GetAsync(predicate: epc => epc.Id == deleteEducationProgramDevelopmentRequest.Id);
        EducationProgramDevelopment deletedEducationProgramDevelopment = await _educationProgramDevelopmentDal.DeleteAsync(educationProgramDevelopment);
        DeletedEducationProgramDevelopmentResponse deletedEducationProgramDevelopmentResponse = _mapper.Map<DeletedEducationProgramDevelopmentResponse>(deletedEducationProgramDevelopment);
        return deletedEducationProgramDevelopmentResponse;
    }

    public async Task<GetEducationProgramDevelopmentResponse> GetByIdAsync(Guid id)
    {
        var educationProgramDevelopmentId = await _educationProgramDevelopmentDal.GetAsync(epc => epc.Id == id);
        var mappedEducationProgramDevelopment = _mapper.Map<GetEducationProgramDevelopmentResponse>(educationProgramDevelopmentId);
        return mappedEducationProgramDevelopment;
    }      

    public async Task<IPaginate<GetListEducationProgramDevelopmentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var educationProgramDevelopmentList = await _educationProgramDevelopmentDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedEducationProgramDevelopmentListed = _mapper.Map<Paginate<GetListEducationProgramDevelopmentResponse>>(educationProgramDevelopmentList);
        return mappedEducationProgramDevelopmentListed;
    }

    public async Task<UpdatedEducationProgramDevelopmentResponse> UpdateAsync(UpdateEducationProgramDevelopmentRequest updateEducationProgramDevelopmentRequest)
    {
        EducationProgramDevelopment educationProgramDevelopment = _mapper.Map<EducationProgramDevelopment>(updateEducationProgramDevelopmentRequest);
        EducationProgramDevelopment updatedEducationProgramDevelopment = await _educationProgramDevelopmentDal.UpdateAsync(educationProgramDevelopment);
        UpdatedEducationProgramDevelopmentResponse updatedEducationProgramDevelopmentResponse= _mapper.Map<UpdatedEducationProgramDevelopmentResponse>(updatedEducationProgramDevelopment);
        return updatedEducationProgramDevelopmentResponse;
    }
}