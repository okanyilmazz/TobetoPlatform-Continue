using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonCategoryRequests;
using Business.Dtos.Responses.LessonCategoryResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes;

public class LessonCategoryManager : ILessonCategoryService
{
    ILessonCategoryDal _lessonCategoryDal;
    IMapper _mapper;
    LessonCategoryBusinessRules _lessonCategoryBusinessRules;

    public LessonCategoryManager(ILessonCategoryDal lessonCategoryDal, IMapper mapper, LessonCategoryBusinessRules lessonCategoryBusinessRules )
    {
        _lessonCategoryDal = lessonCategoryDal;
        _mapper = mapper;
        _lessonCategoryBusinessRules = lessonCategoryBusinessRules;
    }

    public async Task<CreatedLessonCategoryResponse> AddAsync(CreateLessonCategoryRequest createLessonCategoryRequest)
    {
        LessonCategory lessonCategory = _mapper.Map<LessonCategory>(createLessonCategoryRequest);
        LessonCategory addedLessonCategory = await _lessonCategoryDal.AddAsync(lessonCategory);
        var mappedLessonCategory = _mapper.Map<CreatedLessonCategoryResponse>(addedLessonCategory);
        return mappedLessonCategory;
    }

    public async Task<DeletedLessonCategoryResponse> DeleteAsync(Guid id)
    {
        await _lessonCategoryBusinessRules.IsExistsLessonCategory(id);
        LessonCategory lessonCategory = await _lessonCategoryDal.GetAsync(predicate: l => l.Id == id);
        LessonCategory deletedLessonCategory = await _lessonCategoryDal.DeleteAsync(lessonCategory);
        var mappedLessonCategory = _mapper.Map<DeletedLessonCategoryResponse>(deletedLessonCategory);
        return mappedLessonCategory;
    }

    public async Task<GetLessonCategoryResponse> GetByIdAsync(Guid id)
    {
        var lessonCategory = await _lessonCategoryDal.GetAsync(h => h.Id == id);
        return _mapper.Map<GetLessonCategoryResponse>(lessonCategory);
    }

    public async Task<IPaginate<GetListLessonCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessonCategoryList = await _lessonCategoryDal.GetListAsync(
            index:pageRequest.PageIndex,
            size:pageRequest.PageSize);

        var mappedLessonCategory = _mapper.Map<Paginate<GetListLessonCategoryResponse>>(lessonCategoryList);
        return mappedLessonCategory;
    }

    public async Task<UpdatedLessonCategoryResponse> UpdateAsync(UpdateLessonCategoryRequest updateLessonCategoryRequest)
    {
        await _lessonCategoryBusinessRules.IsExistsLessonCategory(updateLessonCategoryRequest.Id);
        LessonCategory lessonCategory = _mapper.Map<LessonCategory>(updateLessonCategoryRequest);
        LessonCategory updateedLessonCategory = await _lessonCategoryDal.UpdateAsync(lessonCategory);
        var mappedLessonCategory = _mapper.Map<UpdatedLessonCategoryResponse>(updateedLessonCategory);
        return mappedLessonCategory;
    }
}
