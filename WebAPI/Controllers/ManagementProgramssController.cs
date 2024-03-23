using Business.Abstracts;
using Business.Dtos.Requests.ManagementProgramRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagementProgramsController : ControllerBase
{
    IManagementProgramService _managementProgramService;

    public ManagementProgramsController(IManagementProgramService managementProgramService)
    {
        _managementProgramService = managementProgramService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _managementProgramService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _managementProgramService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ManagementPrograms.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateManagementProgramRequest createManagementProgramRequest)
    {
        var result = await _managementProgramService.AddAsync(createManagementProgramRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ManagementPrograms.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _managementProgramService.DeleteAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ManagementPrograms.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateManagementProgramRequest updateManagementProgramRequest)
    {
        var result = await _managementProgramService.UpdateAsync(updateManagementProgramRequest);
        return Ok(result);
    }
}

