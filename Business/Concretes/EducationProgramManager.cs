using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramRequests;
using Business.Dtos.Requests.FilterRequest;
using Business.Dtos.Responses.EducationProgramResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramManager : IEducationProgramService
{
    IEducationProgramDal _educationProgramDal;
    IMapper _mapper;
    EducationProgramBusinessRules _educationProgramBusinessRules;

    public EducationProgramManager(IEducationProgramDal educationProgramDal, IMapper mapper, EducationProgramBusinessRules educationProgramBusinessRules)
    {
        _educationProgramDal = educationProgramDal;
        _mapper = mapper;
        _educationProgramBusinessRules = educationProgramBusinessRules;
    }

    public async Task<CreatedEducationProgramResponse> AddAsync(CreateEducationProgramRequest createEducationProgramRequest)
    {
        EducationProgram educationProgram = _mapper.Map<EducationProgram>(createEducationProgramRequest);
        EducationProgram addedEducationProgram = await _educationProgramDal.AddAsync(educationProgram);
        var mappedEducationProgram = _mapper.Map<CreatedEducationProgramResponse>(addedEducationProgram);
        return mappedEducationProgram;
    }

    public async Task<DeletedEducationProgramResponse> DeleteAsync(DeleteEducationProgramRequest deleteEducationProgramRequest)
    {
        await _educationProgramBusinessRules.IsExistsEducationProgram(deleteEducationProgramRequest.Id);
        EducationProgram educationProgram = await _educationProgramDal.GetAsync(predicate: ep => ep.Id == deleteEducationProgramRequest.Id);
        EducationProgram deletedEducationProgram = await _educationProgramDal.DeleteAsync(educationProgram);
        DeletedEducationProgramResponse deletedEducationProgramResponse = _mapper.Map<DeletedEducationProgramResponse>(deletedEducationProgram);
        return deletedEducationProgramResponse;

    }

    public async Task<IPaginate<GetListEducationProgramResponse>> GetListAsync(PageRequest pageRequest)
    {
        var educationProgram = await _educationProgramDal.GetListAsync(
            include: ep => ep
            .Include(ep => ep.EducationProgramLevel)
            .Include(ep => ep.EducationProgramDevelopment)
            .Include(ep => ep.AccountEducationPrograms).ThenInclude(ep => ep.Account)
            .Include(ep => ep.EducationProgramLessons).ThenInclude(ep => ep.Lesson)
            .Include(ep => ep.EducationProgramOccupationClasses).ThenInclude(ep => ep.OccupationClass)
            .Include(ep => ep.EducationProgramProgrammingLanguages).ThenInclude(ep => ep.ProgrammingLanguage)
            .Include(ep => ep.EducationProgramSubjects).ThenInclude(ep => ep.Subject)
            .Include(ep => ep.Badge),

            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

        var mappedEducationPrograms = _mapper.Map<Paginate<GetListEducationProgramResponse>>(educationProgram);
        return mappedEducationPrograms;
    }


    public async Task<IPaginate<GetListEducationProgramResponse>> GetListByFiltered(EducationProgramFilterRequest educationProgramFilterRequest)
    {
        var educationProgramList = await _educationProgramDal.GetListAsync(
            include: ep => ep.Include(ep => ep.EducationProgramProgrammingLanguages)
                            .Include(ep => ep.EducationProgramSubjects)
                            .Include(ep => ep.AccountEducationPrograms));

        var filteredEducationPrograms = educationProgramList.Items
            .Where(e =>
                (educationProgramFilterRequest.EducationProgramLevelId == Guid.Empty || e.EducationProgramLevelId == educationProgramFilterRequest.EducationProgramLevelId) &&

                (educationProgramFilterRequest.ProgrammingLanguageId == Guid.Empty || e.EducationProgramProgrammingLanguages.Any(eppl => eppl.ProgrammingLanguageId == educationProgramFilterRequest.ProgrammingLanguageId)) &&

                (educationProgramFilterRequest.SubjectId == Guid.Empty || e.EducationProgramSubjects.Any(eps => eps.SubjectId == educationProgramFilterRequest.SubjectId)) &&

                (educationProgramFilterRequest.EducationProgramDevelopmentId == Guid.Empty || e.EducationProgramDevelopmentId == educationProgramFilterRequest.EducationProgramDevelopmentId) &&

                //(educationProgramFilterRequest.AccountId == Guid.Empty || e.AccountEducationPrograms.Any(aep => aep.AccountId == educationProgramFilterRequest.AccountId)) &&
                (
                    educationProgramFilterRequest.CompleteStatus == -1 ? true :
                    educationProgramFilterRequest.CompleteStatus == 0 ? e.AccountEducationPrograms.Any(aep => aep.AccountId == educationProgramFilterRequest.RequestingAccountId) :
                    educationProgramFilterRequest.CompleteStatus == 1 ? e.AccountEducationPrograms.Any(aep => aep.StatusPercent == 0 && aep.AccountId == educationProgramFilterRequest.RequestingAccountId) :
                    educationProgramFilterRequest.CompleteStatus == 2 ? e.AccountEducationPrograms.Any(aep => aep.StatusPercent == 100 && aep.AccountId == educationProgramFilterRequest.RequestingAccountId) :
                    educationProgramFilterRequest.CompleteStatus == 3 ? e.AccountEducationPrograms.Any(aep => aep.StatusPercent > 0 && aep.StatusPercent < 100 && aep.AccountId == educationProgramFilterRequest.RequestingAccountId) : true
                ) &&

                (
                  educationProgramFilterRequest.Paid == -1 ? true :
                    educationProgramFilterRequest.Paid == 0 ? e.Price > 0 :
                    educationProgramFilterRequest.Paid == 1 ? e.Price == 0 :
                    true
                ) &&
                  (
                  educationProgramFilterRequest.SpecialForMe == true ? e.AccountEducationPrograms.Any(aep => aep.AccountId == educationProgramFilterRequest.RequestingAccountId) :
                    true
                )
            )
            .ToList();

        var mappedEducationProgram = _mapper.Map<Paginate<GetListEducationProgramResponse>>(filteredEducationPrograms);
        return mappedEducationProgram;
    }

    public async Task<IPaginate<GetListEducationProgramResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var educationProgramList = await _educationProgramDal.GetListAsync(
            include: e => e.Include(o => o.AccountEducationPrograms).ThenInclude(aep => aep.Account));

        var filteredEducationPrograms = educationProgramList
            .Items.Where(e => e.AccountEducationPrograms.Any(s => s.AccountId == accountId)).ToList();
        var mappedEducationProgram = _mapper.Map<Paginate<GetListEducationProgramResponse>>(filteredEducationPrograms);
        return mappedEducationProgram;
    }


    public async Task<IPaginate<GetListEducationProgramResponse>> GetByOccupationClassIdAsync(Guid occupationClassId)
    {
        var educationProgramList = await _educationProgramDal.GetListAsync(
            include: e => e.Include(o => o.EducationProgramOccupationClasses).ThenInclude(epoc => epoc.OccupationClass));

        var filteredEducationPrograms = educationProgramList
            .Items.Where(e => e.EducationProgramOccupationClasses.Any(s => s.OccupationClassId == occupationClassId)).ToList();
        var mappedEducationProgram = _mapper.Map<Paginate<GetListEducationProgramResponse>>(filteredEducationPrograms);
        return mappedEducationProgram;
    }

    public async Task<UpdatedEducationProgramResponse> UpdateAsync(UpdateEducationProgramRequest updateEducationProgramRequest)
    {
        EducationProgram EducationProgram = _mapper.Map<EducationProgram>(updateEducationProgramRequest);
        EducationProgram updateedEducationProgram = await _educationProgramDal.UpdateAsync(EducationProgram);
        var mappedEducationProgram = _mapper.Map<UpdatedEducationProgramResponse>(updateedEducationProgram);
        return mappedEducationProgram;
    }

    public async Task<GetEducationProgramResponse> GetByIdAsync(Guid id)
    {
        var educationProgram = await _educationProgramDal.GetAsync(ep => ep.Id == id);
        var mappedEducationProgram = _mapper.Map<GetEducationProgramResponse>(educationProgram);
        return mappedEducationProgram;
    }
}