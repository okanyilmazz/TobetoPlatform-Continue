﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses.LessonModuleResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class LessonModuleManager : ILessonModuleService
{
    ILessonModuleDal _lessonModuleDal;
    IMapper _mapper;
    LessonModuleBusinessRules _lessonModuleBusinessRules;


    public LessonModuleManager(ILessonModuleDal lessonModuleDal, IMapper mapper, LessonModuleBusinessRules lessonModuleBusinessRules)
    {
        _lessonModuleDal = lessonModuleDal;
        _mapper = mapper;
        _lessonModuleBusinessRules = lessonModuleBusinessRules;
    }

    public async Task<CreatedLessonModuleResponse> AddAsync(CreateLessonModuleRequest createLessonModuleRequest)
    {
        LessonModule lessonModule = _mapper.Map<LessonModule>(createLessonModuleRequest);
        LessonModule addedLessonModule = await _lessonModuleDal.AddAsync(lessonModule);
        CreatedLessonModuleResponse createdLessonModuleResponse = _mapper.Map<CreatedLessonModuleResponse>(addedLessonModule);
        return createdLessonModuleResponse;
    }

    public async Task<DeletedLessonModuleResponse> DeleteAsync(Guid id)
    {
        await _lessonModuleBusinessRules.IsExistsLessonModule(id);
        LessonModule lessonModule = await _lessonModuleDal.GetAsync(predicate: l => l.Id == id);
        LessonModule deletedLessonModule = await _lessonModuleDal.DeleteAsync(lessonModule);
        DeletedLessonModuleResponse deletedLessonModuleResponse = _mapper.Map<DeletedLessonModuleResponse>(deletedLessonModule);
        return deletedLessonModuleResponse;
    }

    public async Task<UpdatedLessonModuleResponse> UpdateAsync(UpdateLessonModuleRequest updateLessonModuleRequest)
    {
        await _lessonModuleBusinessRules.IsExistsLessonModule(updateLessonModuleRequest.Id);
        LessonModule lessonModule = _mapper.Map<LessonModule>(updateLessonModuleRequest);
        LessonModule updatedLessonModule = await _lessonModuleDal.UpdateAsync(lessonModule);
        UpdatedLessonModuleResponse updatedLessonModuleResponse = _mapper.Map<UpdatedLessonModuleResponse>(updatedLessonModule);
        return updatedLessonModuleResponse;
    }

    public async Task<IPaginate<GetListLessonModuleResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessonModuleListed = await _lessonModuleDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedListed = _mapper.Map<Paginate<GetListLessonModuleResponse>>(lessonModuleListed);
        return mappedListed;
    }

    public async Task<GetLessonModuleResponse> GetByIdAsync(Guid id)
    {
        var lessonModule = await _lessonModuleDal.GetAsync(lm => lm.Id == id);
        var mappedLessonModule = _mapper.Map<GetLessonModuleResponse>(lessonModule);
        return mappedLessonModule;
    }
}
