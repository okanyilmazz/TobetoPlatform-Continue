using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramLessonRequests;
using Business.Dtos.Responses.EducationProgramLessonResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramLessonManager : IEducationProgramLessonService
{
    IEducationProgramLessonDal _educationProgramLessonDal;
    IMapper _mapper;
    EducationProgramLessonBusinessRules _educationProgramLessonBusinessRules;

    public EducationProgramLessonManager(IEducationProgramLessonDal educationProgramLessonDal, IMapper mapper, EducationProgramLessonBusinessRules educationProgramLessonBusinessRules)
    {
        _educationProgramLessonDal = educationProgramLessonDal;
        _mapper = mapper;
        _educationProgramLessonBusinessRules = educationProgramLessonBusinessRules;
    }

    public async Task<CreatedEducationProgramLessonResponse> AddAsync(CreateEducationProgramLessonRequest createEducationProgramLessonRequest)
    {
        EducationProgramLesson educationProgramLesson = _mapper.Map<EducationProgramLesson>(createEducationProgramLessonRequest);
        EducationProgramLesson addedEducationProgramLesson = await _educationProgramLessonDal.AddAsync(educationProgramLesson);
        CreatedEducationProgramLessonResponse createdEducationProgramLessonResponse = _mapper.Map<CreatedEducationProgramLessonResponse>(addedEducationProgramLesson);
        return createdEducationProgramLessonResponse;
    }

    public async Task<DeletedEducationProgramLessonResponse> DeleteAsync(DeleteEducationProgramLessonRequest deleteEducationProgramLessonRequest)
    {
        await _educationProgramLessonBusinessRules.IsExistsEducationProgramLesson(deleteEducationProgramLessonRequest.Id);
        EducationProgramLesson educationProgramLesson = await _educationProgramLessonDal.GetAsync(predicate: ep => ep.Id == deleteEducationProgramLessonRequest.Id);
        EducationProgramLesson deletedEducationProgramLesson = await _educationProgramLessonDal.DeleteAsync(educationProgramLesson);
        DeletedEducationProgramLessonResponse deletedEducationProgramLessonResponse = _mapper.Map<DeletedEducationProgramLessonResponse>(deletedEducationProgramLesson);
        return deletedEducationProgramLessonResponse;
    }

    public async Task<GetEducationProgramLessonResponse> GetByIdAsync(Guid id)
    {
        var educationProgramLesson = await _educationProgramLessonDal.GetAsync(
            predicate: h => h.Id == id,
            include: epl => epl
                .Include(epl => epl.Lesson).ThenInclude(l => l.LessonSubType)
                .Include(epl => epl.EducationProgram));
        return _mapper.Map<GetEducationProgramLessonResponse>(educationProgramLesson);
    }

    public async Task<IPaginate<GetListEducationProgramLessonResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var educationProgramLesson = await _educationProgramLessonDal.GetListAsync(
            predicate: l => l.EducationProgramId == educationProgramId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Lesson).ThenInclude(l => l.LessonSubType));

        var mappedEducationProgramLesson = _mapper.Map<Paginate<GetListEducationProgramLessonResponse>>(educationProgramLesson);
        return mappedEducationProgramLesson;
    }

    public async Task<IPaginate<GetListEducationProgramLessonResponse>> GetListAsync(PageRequest pageRequest)
    {
        var EducationProgramLesson = await _educationProgramLessonDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: epl => epl
            .Include(epl => epl.Lesson).ThenInclude(l => l.LessonSubType)
            .Include(epl => epl.EducationProgram)
            );
        var mappedEducationProgramLesson = _mapper.Map<Paginate<GetListEducationProgramLessonResponse>>(EducationProgramLesson);
        return mappedEducationProgramLesson;
    }

    public async Task<UpdatedEducationProgramLessonResponse> UpdateAsync(UpdateEducationProgramLessonRequest updateEducationProgramLessonRequest)
    {
        await _educationProgramLessonBusinessRules.IsExistsEducationProgramLesson(updateEducationProgramLessonRequest.Id);
        EducationProgramLesson educationProgramLesson = _mapper.Map<EducationProgramLesson>(updateEducationProgramLessonRequest);
        EducationProgramLesson updatedEducationProgramLesson = await _educationProgramLessonDal.UpdateAsync(educationProgramLesson);
        UpdatedEducationProgramLessonResponse updatedEducationProgramLessonResponse = _mapper.Map<UpdatedEducationProgramLessonResponse>(updatedEducationProgramLesson);
        return updatedEducationProgramLessonResponse;
    }
}
