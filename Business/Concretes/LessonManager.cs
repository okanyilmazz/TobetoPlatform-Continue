using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonRequests;
using Business.Dtos.Responses.LessonResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class LessonManager : ILessonService
{
    ILessonDal _lessonDal;
    IMapper _mapper;
    LessonBusinessRules _lessonBusinessRules;

    public LessonManager(ILessonDal lessonDal, IMapper mapper, LessonBusinessRules lessonBusinessRules)
    {
        _lessonDal = lessonDal;
        _mapper = mapper;
        _lessonBusinessRules = lessonBusinessRules;
    }

    public async Task<CreatedLessonResponse> AddAsync(CreateLessonRequest createLessonRequest)
    {
        Lesson lesson = _mapper.Map<Lesson>(createLessonRequest);
        Lesson addedLesson = await _lessonDal.AddAsync(lesson);
        CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(addedLesson);
        return createdLessonResponse;
    }

    public async Task<DeletedLessonResponse> DeleteAsync(Guid id)
    {
        await _lessonBusinessRules.IsExistsLesson(id);
        Lesson lesson = await _lessonDal.GetAsync(predicate: l => l.Id == id);
        Lesson deletedLesson = await _lessonDal.DeleteAsync(lesson);
        DeletedLessonResponse deletedLessonResponse = _mapper.Map<DeletedLessonResponse>(deletedLesson);
        return deletedLessonResponse;
    }

    public async Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessons = await _lessonDal.GetListAsync(
            include: l => l.Include(ep => ep.Language).
            Include(ep => ep.LessonCategory).
            Include(ep => ep.LessonModule).
            Include(ep => ep.ProductionCompany).
            Include(ep => ep.LessonSubType),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedLessons = _mapper.Map<Paginate<GetListLessonResponse>>(lessons);
        return mappedLessons;
    }

    public async Task<IPaginate<GetListLessonResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {

        var lessonList = await _lessonDal.GetListAsync(
            include: l => l.Include(ep => ep.EducationProgramLessons).ThenInclude(epl => epl.EducationProgram).
            Include(ep => ep.Language).
            Include(ep => ep.LessonCategory).
            Include(ep => ep.LessonModule).
            Include(ep => ep.ProductionCompany).
            Include(ep => ep.LessonSubType));

        var filteredLessons = lessonList.Items.Where(e => e.EducationProgramLessons.Any(s => s.EducationProgramId == educationProgramId)).ToList();
        var mappedLesson = _mapper.Map<Paginate<GetListLessonResponse>>(filteredLessons);
        return mappedLesson;
    }

    public async Task<UpdatedLessonResponse> UpdateAsync(UpdateLessonRequest updateLessonRequest)
    {
        await _lessonBusinessRules.IsExistsLesson(updateLessonRequest.Id);
        Lesson lesson = _mapper.Map<Lesson>(updateLessonRequest);
        Lesson updatedLesson = await _lessonDal.UpdateAsync(lesson);
        UpdatedLessonResponse updatedLessonResponse = _mapper.Map<UpdatedLessonResponse>(updatedLesson);
        return updatedLessonResponse;
    }

    public async Task<IPaginate<GetListLessonResponse>> GetByAccountIdAsync(Guid id)
    {
        var lessonList = await _lessonDal.GetListAsync(
           include: l => l.Include(a => a.AccountLessons).ThenInclude(al => al.Account).
            Include(ep => ep.Language).
            Include(ep => ep.LessonCategory).
            Include(ep => ep.LessonModule).
            Include(ep => ep.ProductionCompany).
            Include(ep => ep.LessonSubType));

        var filteredLessons = lessonList
            .Items.SelectMany(l => l.AccountLessons.Where(a => a.Id == id).Select(a => l)).ToList();
        var mappedLesson = _mapper.Map<Paginate<GetListLessonResponse>>(filteredLessons);
        return mappedLesson;
    }

    public async Task<GetLessonResponse> GetByIdAsync(Guid id)
    {
        var lesson = await _lessonDal.GetAsync(
            predicate: l => l.Id == id,
            include: l => l.
            Include(ep => ep.Language).
            Include(ep => ep.LessonCategory).
            Include(ep => ep.LessonModule).
            Include(ep => ep.ProductionCompany).
            Include(ep => ep.LessonSubType));
        var mappedLesson = _mapper.Map<GetLessonResponse>(lesson);
        return mappedLesson;
    }
}
