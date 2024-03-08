using Business.Abstracts;
using Business.Dtos.Requests.LessonCategoryRequests;
using Business.Rules.ValidationRules.FluentValidation.LessonCategoryValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonCategoriesController : ControllerBase
{
    ILessonCategoryService _lessonCategoryService;

    public LessonCategoriesController(ILessonCategoryService lessonCategoryService)
    {
        _lessonCategoryService = lessonCategoryService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonCategoryService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonCategoryService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("LessonCategories.Get")]
    [CustomValidation(typeof(CreateLessonCategoryRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonCategoryRequest createLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.AddAsync(createLessonCategoryRequest);
        return Ok(result);
    }

    [CacheRemove("LessonCategories.Get")]
    [CustomValidation(typeof(UpdateLessonCategoryRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonCategoryRequest updateLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.UpdateAsync(updateLessonCategoryRequest);
        return Ok(result);
    }

    [CacheRemove("LessonCategories.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonCategoryRequest deleteLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.DeleteAsync(deleteLessonCategoryRequest);
        return Ok(result);
    }
}
