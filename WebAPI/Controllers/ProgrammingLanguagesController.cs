using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.ProgrammingLanguageValidators;
using Business.Dtos.Requests.ProgrammingLanguageRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : ControllerBase
{
    IProgrammingLanguageService _programmingLanguageService;

    public ProgrammingLanguagesController(IProgrammingLanguageService programmingLanguageService)
    {
        _programmingLanguageService = programmingLanguageService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _programmingLanguageService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _programmingLanguageService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProgrammingLanguages.Get")]
    [CustomValidation(typeof(CreateProgrammingLanguageRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProgrammingLanguageRequest createProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.AddAsync(createProgrammingLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProgrammingLanguages.Get")]
    [CustomValidation(typeof(UpdateProgrammingLanguageRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.UpdateAsync(updateProgrammingLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProgrammingLanguages.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProgrammingLanguageRequest deleteProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.DeleteAsync(deleteProgrammingLanguageRequest);
        return Ok(result);
    }
}