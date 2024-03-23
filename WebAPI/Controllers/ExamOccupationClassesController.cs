using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.ExamOccupationClassRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamOccupationClassesController : ControllerBase
{
    IExamOccupationClassService _examOccupationClassService;

    public ExamOccupationClassesController(IExamOccupationClassService examOccupationClassService)
    {
        _examOccupationClassService = examOccupationClassService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _examOccupationClassService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examOccupationClassService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamOccupationClassRequest createExamOccupationClassRequest)
    {
        var result = await _examOccupationClassService.AddAsync(createExamOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamOccupationClassRequest updateExamOccupationClassRequest)
    {
        var result = await _examOccupationClassService.UpdateAsync(updateExamOccupationClassRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _examOccupationClassService.DeleteAsync(id);
        return Ok(result);
    }
}