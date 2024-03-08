using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SubjectRequests;
using Business.Dtos.Responses.SubjectResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class SubjectManager : ISubjectService
{
    ISubjectDal _subjectDal;
    IMapper _mapper;
    SubjectBusinessRules _subjectBusinessRules;

    public SubjectManager(ISubjectDal subjectDal, IMapper mapper, SubjectBusinessRules subjectBusinessRules)
    {
        _subjectDal = subjectDal;
        _mapper = mapper;
        _subjectBusinessRules = subjectBusinessRules;
    }

    public async Task<CreatedSubjectResponse> AddAsync(CreateSubjectRequest createSubjectRequest)
    {
        var subject = _mapper.Map<Subject>(createSubjectRequest);
        var addedSubject = await _subjectDal.AddAsync(subject);
        var responseSubject = _mapper.Map<CreatedSubjectResponse>(addedSubject);
        return responseSubject;
    }

    public async Task<DeletedSubjectResponse> DeleteAsync(DeleteSubjectRequest deleteSubjectRequest)
    {
        await _subjectBusinessRules.IsExistSubject(deleteSubjectRequest.Id);
        var subject = _mapper.Map<Subject>(deleteSubjectRequest);
        var deletedSubject = await _subjectDal.DeleteAsync(subject);
        var responseSubject = _mapper.Map<DeletedSubjectResponse>(deletedSubject);
        return responseSubject;
    }
      

    public async Task<GetListSubjectResponse> GetByIdAsync(Guid id)
    {
        var subject = await _subjectDal.GetAsync(s => s.Id == id);
        var mappedSubject = _mapper.Map<GetListSubjectResponse>(subject);
        return mappedSubject;
    }

    public async Task<IPaginate<GetListSubjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var subjectListed = await _subjectDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedListed = _mapper.Map<Paginate<GetListSubjectResponse>>(subjectListed);
        return mappedListed;
    }

    public async Task<UpdatedSubjectResponse> UpdateAsync(UpdateSubjectRequest updateSubjectRequest)
    {
        await _subjectBusinessRules.IsExistSubject(updateSubjectRequest.Id);
        var subject = _mapper.Map<Subject>(updateSubjectRequest);
        var updatedSubject = await _subjectDal.UpdateAsync(subject);
        var responseSubject = _mapper.Map<UpdatedSubjectResponse>(updatedSubject);
        return responseSubject;
    }
}   