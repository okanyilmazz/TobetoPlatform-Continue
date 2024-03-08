using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.HomeworkRequests;
using Business.Dtos.Responses.HomeworkResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class HomeworkManager : IHomeworkService
{
    IHomeworkDal _homeworkDal;
    IMapper _mapper;
    HomeworkBusinessRules _homeworkBusinessRules;

    public HomeworkManager(IHomeworkDal homeworkDal, IMapper mapper, HomeworkBusinessRules homeworkBusinessRules)
    {
        _homeworkDal = homeworkDal;
        _mapper = mapper;
        _homeworkBusinessRules = homeworkBusinessRules;
    }

    public async Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest)
    {
        Homework homework = _mapper.Map<Homework>(createHomeworkRequest);
        Homework addedHomework = await _homeworkDal.AddAsync(homework);
        CreatedHomeworkResponse createdHomeworkResponse = _mapper.Map<CreatedHomeworkResponse>(addedHomework);
        return createdHomeworkResponse;

    }

    public async Task<DeletedHomeworkResponse> DeleteAsync(DeleteHomeworkRequest deleteHomeworkRequest)
    {
        await _homeworkBusinessRules.IsExistsHomework(deleteHomeworkRequest.Id);
        Homework homework = await _homeworkDal.GetAsync(predicate: l => l.Id == deleteHomeworkRequest.Id);
        Homework deletedHomework = await _homeworkDal.DeleteAsync(homework);
        DeletedHomeworkResponse deletedHomeworkResponse = _mapper.Map<DeletedHomeworkResponse>(deletedHomework);
        return deletedHomeworkResponse;
    }

    public async Task<IPaginate<GetListHomeworkResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var homeworks = await _homeworkDal.GetListAsync(
            include: l => l.Include(a => a.AccountHomeworks).ThenInclude(al => al.Account));
        var filteredHomeworks = homeworks.Items.Where(e => e.AccountHomeworks.Any(s => s.AccountId == accountId)).ToList();
        var mappedHomeworks = _mapper.Map<Paginate<GetListHomeworkResponse>>(filteredHomeworks);
        return mappedHomeworks;
    }

    public async Task<GetHomeworkResponse> GetByIdAsync(Guid id)
    {
        var homework = await _homeworkDal.GetAsync(
            predicate: h => h.Id == id,
            include: h => h
            .Include(h => h.Lesson));

        var mappedHomework = _mapper.Map<GetHomeworkResponse>(homework);
        return mappedHomework;
    }

    public async Task<IPaginate<GetListHomeworkResponse>> GetByLessonIdAsync(Guid lessonId)
    {
        var homeworks = await _homeworkDal.GetListAsync(
        predicate: h => h.LessonId == lessonId,
        include: h => h
        .Include(h => h.Lesson));
        var mappedHomeworks = _mapper.Map<Paginate<GetListHomeworkResponse>>(homeworks);
        return mappedHomeworks;
    }

    public async Task<IPaginate<GetListHomeworkResponse>> GetListAsync(PageRequest pageRequest)
    {
        var homework = await _homeworkDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: h => h.Include(h => h.Lesson));

        var mappedHomework = _mapper.Map<Paginate<GetListHomeworkResponse>>(homework);
        return mappedHomework;
    }

    public async Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest)
    {
        await _homeworkBusinessRules.IsExistsHomework(updateHomeworkRequest.Id);
        Homework homework = _mapper.Map<Homework>(updateHomeworkRequest);
        Homework updatedHomework = await _homeworkDal.UpdateAsync(homework);
        UpdatedHomeworkResponse updatedHomeworkResponse = _mapper.Map<UpdatedHomeworkResponse>(updatedHomework);
        return updatedHomeworkResponse;
    }
}
