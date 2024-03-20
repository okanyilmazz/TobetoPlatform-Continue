using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SessionManager : ISessionService
{

    ISessionDal _sessionDal;
    IMapper _mapper;
    SessionBusinessRules _sessionBusinessRules;

    public SessionManager(ISessionDal sessionDal, IMapper mapper, SessionBusinessRules sessionBusinessRules)
    {
        _sessionDal = sessionDal;
        _mapper = mapper;
        _sessionBusinessRules = sessionBusinessRules;
    }

    public async Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
    {
        Session session = _mapper.Map<Session>(createSessionRequest);
        Session createdSession = await _sessionDal.AddAsync(session);
        CreatedSessionResponse createdSessionResponse = _mapper.Map<CreatedSessionResponse>(createdSession);
        return createdSessionResponse;
    }

    public async Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest)
    {
        await _sessionBusinessRules.IsExistsSession(deleteSessionRequest.Id);
        Session session = await _sessionDal.GetAsync(predicate: s => s.Id == deleteSessionRequest.Id);
        Session deletedSession = await _sessionDal.DeleteAsync(session);
        DeletedSessionResponse deletedSessionResponse = _mapper.Map<DeletedSessionResponse>(deletedSession);
        return deletedSessionResponse;
    }

    public async Task<IPaginate<GetListSessionResponse>> GetListWithInstructorAsync(PageRequest pageRequest)
    {
        var session = await _sessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include:s=>s
            .Include(s => s.Lesson)
            .ThenInclude(l => l.EducationProgramLessons)
            .ThenInclude(epl => epl.EducationProgram)
            .ThenInclude(ep => ep.EducationProgramOccupationClasses)
            .ThenInclude(epoc => epoc.OccupationClass)
            .Include(s => s.Lesson)
            .ThenInclude(s => s.EducationProgramLessons)
            .ThenInclude(s => s.EducationProgram)
            .ThenInclude(s => s.EducationProgramOccupationClasses)
            .ThenInclude(s => s.OccupationClass)
            .ThenInclude(oc => oc.AccountOccupationClasses)
            .ThenInclude(aoc => aoc.Account)
            .ThenInclude(a => a.User),

            predicate:s=>s.Lesson.EducationProgramLessons
            .Any(epl=>epl.EducationProgram.AccountEducationPrograms
            .Any(aep=>aep.Account.User.UserOperationClaims
            .Any(uoc=>uoc.OperationClaim.Name==Roles.Instructor))));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }

    public async Task<IPaginate<GetListSessionResponse>> GetByIdWithInstructorAsync(Guid id, PageRequest pageRequest)
    {
        var session = await _sessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            predicate: s => s.AccountSessions.
            Any(a => a.Account.User.UserOperationClaims.
            Any(claim => claim.OperationClaim.Name == Roles.Instructor) && a.SessionId == id),
            include: s => s
            .Include(s => s.Lesson)
            .ThenInclude(l => l.EducationProgramLessons)
            .ThenInclude(epl => epl.EducationProgram)
            .ThenInclude(ep => ep.EducationProgramOccupationClasses)
            .ThenInclude(epoc => epoc.OccupationClass)
            .Include(s => s.Lesson)
            .ThenInclude(s => s.EducationProgramLessons)
            .ThenInclude(s => s.EducationProgram)
            .ThenInclude(s => s.EducationProgramOccupationClasses)
            .ThenInclude(s => s.OccupationClass)
            .ThenInclude(oc => oc.AccountOccupationClasses)
            .ThenInclude(aoc => aoc.Account)
            .ThenInclude(a => a.User));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }


    public async Task<IPaginate<GetListSessionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var session = await _sessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: s => s
            .Include(s => s.Lesson)
            .ThenInclude(l => l.EducationProgramLessons)
            .ThenInclude(epl => epl.EducationProgram)
            .ThenInclude(ep => ep.EducationProgramOccupationClasses)
            .ThenInclude(epoc => epoc.OccupationClass)
            .Include(s => s.Lesson)
            .ThenInclude(s => s.EducationProgramLessons)
            .ThenInclude(s => s.EducationProgram)
            .ThenInclude(s => s.EducationProgramOccupationClasses)
            .ThenInclude(s => s.OccupationClass)
            .ThenInclude(oc => oc.AccountOccupationClasses)
            .ThenInclude(aoc => aoc.Account)
            .ThenInclude(a => a.User));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }

    public async Task<GetSessionResponse> GetByIdAsync(Guid id)
    {
        var session = await _sessionDal.GetAsync(
       predicate: s => s.Id == id,
       include: s => s
       .Include(s => s.Lesson));

        var mappedSession = _mapper.Map<GetSessionResponse>(session);
        return mappedSession;
    }

    public async Task<IPaginate<GetListSessionResponse>> GetByLessonIdAsync(Guid lessonId)
    {
        var session = await _sessionDal.GetListAsync(
            predicate: s => s.LessonId == lessonId,
            include: s => s
            .Include(s => s.Lesson));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }

    public async Task<IPaginate<GetListSessionResponse>> GetByAccountAndLessonIdAsync(Guid accountId,Guid lessonId)
    {
        var session = await _sessionDal.GetListAsync(
           predicate: s => s.LessonId == lessonId &&
            s.AccountSessions.Any(a => a.AccountId == accountId && a.Status==true),
            include: s => s
            .Include(s => s.Lesson)
            .Include(s => s.AccountSessions)
            .Include(s => s.Lesson).ThenInclude(l => l.EducationProgramLessons)
            .ThenInclude(epl => epl.EducationProgram.EducationProgramOccupationClasses)
            .ThenInclude(epoc => epoc.OccupationClass.AccountOccupationClasses)
            .ThenInclude(aoc => aoc.Account.User));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }

    public async Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
    {
        await _sessionBusinessRules.IsExistsSession(updateSessionRequest.Id);
        Session session = _mapper.Map<Session>(updateSessionRequest);
        Session updatedSession = await _sessionDal.UpdateAsync(session);
        UpdatedSessionResponse updatedSessionResponse = _mapper.Map<UpdatedSessionResponse>(updatedSession);
        return updatedSessionResponse;
    }
}
