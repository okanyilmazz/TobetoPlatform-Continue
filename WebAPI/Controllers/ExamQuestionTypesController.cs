using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.ExamQuestionTypeRequests;
using Core.DataAccess.Paging;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamQuestionTypesController : ControllerBase
{
    IExamQuestionTypeService _examQuestionTypeService;

    public ExamQuestionTypesController(IExamQuestionTypeService examQuestionTypeService)
    {
        _examQuestionTypeService = examQuestionTypeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _examQuestionTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examQuestionTypeService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamQuestionTypeRequest createExamQuestionTypesRequest)
    {
        var result = await _examQuestionTypeService.AddAsync(createExamQuestionTypesRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest)
    {
        var result = await _examQuestionTypeService.UpdateAsync(updateExamQuestionTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _examQuestionTypeService.DeleteAsync(id);
        return Ok(result);
    }
}