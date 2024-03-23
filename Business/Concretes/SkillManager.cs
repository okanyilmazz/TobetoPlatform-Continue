using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SkillRequests;
using Business.Dtos.Responses.SkillResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SkillManager : ISkillService
{
    ISkillDal _skillDal;
    IMapper _mapper;
    SkillBusinessRules _skillBusinessRules;

    public SkillManager(ISkillDal skillDal, IMapper mapper, SkillBusinessRules skillBusinessRules)
    {
        _skillDal = skillDal;
        _mapper = mapper;
        _skillBusinessRules = skillBusinessRules;
    }

    public async Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest)
    {

        Skill skill = _mapper.Map<Skill>(createSkillRequest);
        Skill addedSkill = await _skillDal.AddAsync(skill);
        CreatedSkillResponse createdSkillResponse = _mapper.Map<CreatedSkillResponse>(addedSkill);
        return createdSkillResponse;
    }

    public async Task<DeletedSkillResponse> DeleteAsync(Guid id)
    {
        await _skillBusinessRules.IsExistsSkill(id);
        Skill skill = await _skillDal.GetAsync(predicate: s => s.Id == id);
        Skill deletedSkill = await _skillDal.DeleteAsync(skill);
        DeletedSkillResponse deletedSkillResponse = _mapper.Map<DeletedSkillResponse>(deletedSkill);
        return deletedSkillResponse;
    }

    public async Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest)
    {
        await _skillBusinessRules.IsExistsSkill(updateSkillRequest.Id);
        Skill skill = _mapper.Map<Skill>(updateSkillRequest);
        Skill updatedSkill = await _skillDal.UpdateAsync(skill);
        UpdatedSkillResponse updatedSkillResponse = _mapper.Map<UpdatedSkillResponse>(updatedSkill);
        return updatedSkillResponse;
    }

    public async Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest)
    {
        var skills = await _skillDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedSkills = _mapper.Map<Paginate<GetListSkillResponse>>(skills);
        return mappedSkills;
    }

    public async Task<IPaginate<GetListSkillResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var skills = await _skillDal.GetListAsync(
            include: s => s.Include(a => a.AccountSkills).ThenInclude(ask => ask.Account));
        var filteredSkills = skills.Items.Where(e => e.AccountSkills.Any(s => s.Account.Id == accountId)).ToList();
        var mappedSkills = _mapper.Map<Paginate<GetListSkillResponse>>(filteredSkills);
        return mappedSkills;


    }

    public async Task<GetSkillResponse> GetByIdAsync(Guid id)
    {
        var skill = await _skillDal.GetAsync(s => s.Id == id);
        var mappedSkill = _mapper.Map<GetSkillResponse>(skill);
        return mappedSkill;
    }
}

