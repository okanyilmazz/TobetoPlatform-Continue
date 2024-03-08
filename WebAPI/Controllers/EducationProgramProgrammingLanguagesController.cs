using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.EducationProgramProgrammingLanguageRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramProgrammingLanguagesController : ControllerBase
{
    IEducationProgramProgrammingLanguageService _educationProgramProgrammingLanguageService;

    public EducationProgramProgrammingLanguagesController(IEducationProgramProgrammingLanguageService educationProgramProgrammingLanguageservice)
    {
        _educationProgramProgrammingLanguageService = educationProgramProgrammingLanguageservice;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramProgrammingLanguageService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramProgrammingLanguageService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramProgrammingLanguages.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramProgrammingLanguageRequest CreateEducationProgramProgrammingLanguageRequest)
    {
        var result = await _educationProgramProgrammingLanguageService.AddAsync(CreateEducationProgramProgrammingLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramProgrammingLanguages.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramProgrammingLanguageRequest deleteEducationProgramProgrammingLanguageRequest)
    {
        var result = await _educationProgramProgrammingLanguageService.DeleteAsync(deleteEducationProgramProgrammingLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramProgrammingLanguages.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest)
    {
        var result = await _educationProgramProgrammingLanguageService.UpdateAsync(updateEducationProgramProgrammingLanguageRequest);
        return Ok(result);
    }
}
