using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.EducationProgramLevelRequests;
using Core.DataAccess.Paging;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramLevelsController : ControllerBase
{
    IEducationProgramLevelService _educationProgramLevelService;

    public EducationProgramLevelsController(IEducationProgramLevelService educationProgramLevelService)
    {
        _educationProgramLevelService = educationProgramLevelService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest
)
    {
        var result = await _educationProgramLevelService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramLevelService.GetByIdAsync(id);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLevelRequest createEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.AddAsync(createEducationProgramLevelRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLevelRequest updateEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.UpdateAsync(updateEducationProgramLevelRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramLevelRequest deleteEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.DeleteAsync(deleteEducationProgramLevelRequest);
        return Ok(result);
    }
}
