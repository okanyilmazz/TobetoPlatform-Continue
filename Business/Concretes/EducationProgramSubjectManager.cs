using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramSubjectRequests;
using Business.Dtos.Responses.EducationProgramSubjectResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class EducationProgramSubjectManager : IEducationProgramSubjectService
{
    IEducationProgramSubjectDal _educationProgramSubjectDal;
    IMapper _mapper;
    EducationProgramSubjectBusinessRules _educationProgramSubjectBusinessRules;

    public EducationProgramSubjectManager(IEducationProgramSubjectDal educationProgramSubjectDal, IMapper mapper, EducationProgramSubjectBusinessRules educationProgramSubjectBusinessRules)
    {
        _educationProgramSubjectDal = educationProgramSubjectDal;
        _mapper = mapper;
        _educationProgramSubjectBusinessRules = educationProgramSubjectBusinessRules;
    }

    public async Task<CreatedEducationProgramSubjectResponse> AddAsync(CreateEducationProgramSubjectRequest createEducationProgramSubjectRequest)
    {
        EducationProgramSubject educationProgramSubject = _mapper.Map<EducationProgramSubject>(createEducationProgramSubjectRequest);
        EducationProgramSubject addedEducationProgramSubject = await _educationProgramSubjectDal.AddAsync(educationProgramSubject);
        var mappedEducationProgramSubject = _mapper.Map<CreatedEducationProgramSubjectResponse>(addedEducationProgramSubject);
        return mappedEducationProgramSubject;
    }

    public async Task<DeletedEducationProgramSubjectResponse> DeleteAsync(Guid id)
    {
        await _educationProgramSubjectBusinessRules.IsExistsEducationProgramSubject(id);
        EducationProgramSubject educationProgramSubject = await _educationProgramSubjectDal.GetAsync(predicate: eps => eps.Id == id);
        EducationProgramSubject deletedEducationProgramSubject = await _educationProgramSubjectDal.DeleteAsync(educationProgramSubject);
        DeletedEducationProgramSubjectResponse deletedEducationProgramSubjectResponse = _mapper.Map<DeletedEducationProgramSubjectResponse>(deletedEducationProgramSubject);
        return deletedEducationProgramSubjectResponse;
    }

    public async Task<GetEducationProgramSubjectResponse> GetByIdAsync(Guid id)
    {
        var educationProgramSubject = await _educationProgramSubjectDal.GetAsync(eps => eps.Id == id);
        var mappedEducationProgramSubject = _mapper.Map<GetEducationProgramSubjectResponse>(educationProgramSubject);
        return mappedEducationProgramSubject;
    }

    public async Task<IPaginate<GetListEducationProgramSubjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var educationProgramSubjects = await _educationProgramSubjectDal.GetListAsync(index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedEducationProgramSubject = _mapper.Map<Paginate<GetListEducationProgramSubjectResponse>>(educationProgramSubjects);
        return mappedEducationProgramSubject;
    }

    public async Task<UpdatedEducationProgramSubjectResponse> UpdateAsync(UpdateEducationProgramSubjectRequest updateEducationProgramSubjectRequest)
    {
        EducationProgramSubject educationProgramSubject = _mapper.Map<EducationProgramSubject>(updateEducationProgramSubjectRequest);
        EducationProgramSubject updatedEducationProgramSubject = await _educationProgramSubjectDal.UpdateAsync(educationProgramSubject);
        UpdatedEducationProgramSubjectResponse updatedEducationProgramSubjectResponse = _mapper.Map<UpdatedEducationProgramSubjectResponse>(updatedEducationProgramSubject);
        return updatedEducationProgramSubjectResponse;
    }
}