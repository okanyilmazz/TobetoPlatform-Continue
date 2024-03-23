using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.QuestionValidators;
using Business.Dtos.Requests.QuestionRequests;
using Core.CrossCuttingConcerns.Authorization;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    [SecuredOperation("Admin", "Instructor", "Moderator")]
    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _questionService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByExamId")]
    public async Task<IActionResult> GetByExamIdAsync(Guid Id, [FromQuery] PageRequest pageRequest)
    {
        var result = await _questionService.GetByExamIdAsync(Id, pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _questionService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Questions.Get")]
    [CustomValidation(typeof(CreateQuestionRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateQuestionRequest createQuestionRequest)
    {
        var result = await _questionService.AddAsync(createQuestionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Questions.Get")]
    [CustomValidation(typeof(UpdateQuestionRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionRequest updateQuestionRequest)
    {
        var result = await _questionService.UpdateAsync(updateQuestionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Questions.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _questionService.DeleteAsync(id);
        return Ok(result);
    }
}
