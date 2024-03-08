using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Mvc;
using Core.DataAccess.Paging;
using Business.Rules.ValidationRules.FluentValidation.AnnouncementValidators;
using Business.Dtos.Requests.AnnouncementRequests;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    IAnnouncementService _announcementService;

    public AnnouncementsController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest )
    {
        var result = await _announcementService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _announcementService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Announcements.Get")]
    [CustomValidation(typeof(CreateAnnouncementRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementRequest createAnnouncementRequest)
    {
        var result = await _announcementService.AddAsync(createAnnouncementRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Announcements.Get")]
    [CustomValidation(typeof(UpdateAnnouncementRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        var result = await _announcementService.UpdateAsync(updateAnnouncementRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Announcements.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        var result = await _announcementService.DeleteAsync(deleteAnnouncementRequest);
        return Ok(result);
    }
}
