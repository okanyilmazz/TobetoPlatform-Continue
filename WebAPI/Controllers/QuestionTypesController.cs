using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.QuestionTypeValidators;
using Business.Dtos.Requests.QuestionTypeRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionTypesController : Controller
{
    IQuestionTypeService _questionTypeService;

    public QuestionTypesController(IQuestionTypeService questionTypeService)
    {
        _questionTypeService = questionTypeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _questionTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _questionTypeService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByQuestionId")]
    public async Task<IActionResult> GetByQuestionIdAsync(Guid questionId)
    {
        var result = await _questionTypeService.GetByQuestionIdAsync(questionId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByExamId")]
    public async Task<IActionResult> GetByExamIdAsync(Guid examId,[FromQuery] PageRequest pageRequest)
    {
        var result = await _questionTypeService.GetByExamIdAsync(examId, pageRequest);
        return Ok(result);
    }

    

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("QuestionTypes.Get")]
    [CustomValidation(typeof(CreateQuestionTypeRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateQuestionTypeRequest createQuestionTypeRequest)
    {
        var result = await _questionTypeService.AddAsync(createQuestionTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("QuestionTypes.Get")]
    [CustomValidation(typeof(UpdateQuestionTypeRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionTypeRequest updateQuestionTypeRequest)
    {
        var result = await _questionTypeService.UpdateAsync(updateQuestionTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("QuestionTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionTypeRequest deleteQuestionTypeRequest)
    {
        var result = await _questionTypeService.DeleteAsync(deleteQuestionTypeRequest);
        return Ok(result);
    }
}

