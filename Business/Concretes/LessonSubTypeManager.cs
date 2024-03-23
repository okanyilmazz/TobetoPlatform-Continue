using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonSubTypeRequests;
using Business.Dtos.Responses.LessonSubTypeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes;

public class LessonSubTypeManager : ILessonSubTypeService
{

    ILessonSubTypeDal _lessonSubTypeDal;
    IMapper _mapper;
    LessonSubTypeBusinessRules _lessonSubTypeBusinessRules;

    public LessonSubTypeManager(ILessonSubTypeDal lessonSubTypeDal, IMapper mapper, LessonSubTypeBusinessRules lessonSubTypeBusinessRules)
    {
        _lessonSubTypeDal = lessonSubTypeDal;
        _mapper = mapper;
        _lessonSubTypeBusinessRules = lessonSubTypeBusinessRules;
    }

    public async Task<CreatedLessonSubTypeResponse> AddAsync(CreateLessonSubTypeRequest createLessonSubTypeRequest)
    {
        LessonSubType lessonSubType = _mapper.Map<LessonSubType>(createLessonSubTypeRequest);
        LessonSubType addedLessonSubType = await _lessonSubTypeDal.AddAsync(lessonSubType);
        var mappedLessonSubType = _mapper.Map<CreatedLessonSubTypeResponse>(addedLessonSubType);
        return mappedLessonSubType;
    }

    public async Task<DeletedLessonSubTypeResponse> DeleteAsync(Guid id)
    {
        await _lessonSubTypeBusinessRules.IsExistsLessonSubType(id);
        LessonSubType lessonSubType = await _lessonSubTypeDal.GetAsync(predicate: l => l.Id == id);
        LessonSubType deletedLessonSubType = await _lessonSubTypeDal.DeleteAsync(lessonSubType);
        var mappedLessonSubType = _mapper.Map<DeletedLessonSubTypeResponse>(deletedLessonSubType);
        return mappedLessonSubType;
    }

    public async Task<GetLessonSubTypeResponse> GetByIdAsync(Guid id)
    {
        var lessonSubType = await _lessonSubTypeDal.GetAsync(l => l.Id == id);
        var mappedLessonSubType = _mapper.Map<GetLessonSubTypeResponse>(lessonSubType);
        return mappedLessonSubType;
    }

    public async Task<IPaginate<GetListLessonSubTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessonSubTypeList = await _lessonSubTypeDal.GetListAsync(index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedLessonSubType = _mapper.Map<Paginate<GetListLessonSubTypeResponse>>(lessonSubTypeList);
        return mappedLessonSubType;
    }

    public async Task<UpdatedLessonSubTypeResponse> UpdateAsync(UpdateLessonSubTypeRequest updateLessonSubTypeRequest)
    {    await _lessonSubTypeBusinessRules.IsExistsLessonSubType(updateLessonSubTypeRequest.Id);
        LessonSubType lessonSubType = _mapper.Map<LessonSubType>(updateLessonSubTypeRequest);
        LessonSubType updateedLessonSubType = await _lessonSubTypeDal.UpdateAsync(lessonSubType);
        var mappedLessonSubType = _mapper.Map<UpdatedLessonSubTypeResponse>(updateedLessonSubType);
        return mappedLessonSubType;
    }
}
