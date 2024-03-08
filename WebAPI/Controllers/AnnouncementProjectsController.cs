using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.AnnouncementProjectValidators;
using Business.Dtos.Requests.AnnouncementProjectRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementProjectsController : ControllerBase
{
    IAnnouncementProjectService _announcementProjectService;

    public AnnouncementProjectsController(IAnnouncementProjectService announcementProjectService)
    {
        _announcementProjectService = announcementProjectService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _announcementProjectService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _announcementProjectService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementProjects.Get")]
    [CustomValidation(typeof(CreateAnnouncementProjectRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementProjectRequest createAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.AddAsync(createAnnouncementProjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementProjects.Get")]
    [CustomValidation(typeof(UpdateAnnouncementProjectRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.UpdateAsync(updateAnnouncementProjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementProjects.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.DeleteAsync(deleteAnnouncementProjectRequest);
        return Ok(result);
    }
}
