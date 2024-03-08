using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.ExamValidators;
using Business.Dtos.Requests.ExamRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamsController : ControllerBase
{
    IExamService _examService;

    public ExamsController(IExamService examService)
    {
        _examService = examService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _examService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid accountId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _examService.GetByAccountIdAsync(accountId, pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Exams.Get")]
    [CustomValidation(typeof(CreateExamRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamRequest createExamRequest)
    {
        var result = await _examService.AddAsync(createExamRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Exams.Get")]
    [CustomValidation(typeof(UpdateExamRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamRequest updateExamRequest)
    {
        var result = await _examService.UpdateAsync(updateExamRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Exams.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamRequest deleteExamRequest)
    {
        var result = await _examService.DeleteAsync(deleteExamRequest);
        return Ok(result);
    }
}
