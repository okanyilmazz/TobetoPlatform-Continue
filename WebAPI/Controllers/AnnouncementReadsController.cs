using Business.Abstracts;
using Business.Dtos.Requests.AnnouncementReadRequests;
using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Rules.ValidationRules.FluentValidation.AnnouncementReadValidators;
using Business.Rules.ValidationRules.FluentValidation.AnnouncementValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementReadsController : ControllerBase
{
    IAnnouncementReadService _announcementReadService;

    public AnnouncementReadsController(IAnnouncementReadService announcementReadService)
    {
        _announcementReadService = announcementReadService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _announcementReadService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _announcementReadService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementReads.Get")]
    [CustomValidation(typeof(CreateAnnouncementReadRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementReadRequest createAnnouncementReadRequest)
    {
        var result = await _announcementReadService.AddAsync(createAnnouncementReadRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementReads.Get")]
    [CustomValidation(typeof(UpdateAnnouncementReadRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementReadRequest updateAnnouncementReadRequest)
    {
        var result = await _announcementReadService.UpdateAsync(updateAnnouncementReadRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementReads.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementReadRequest deleteAnnouncementReadRequest)
    {
        var result = await _announcementReadService.DeleteAsync(deleteAnnouncementReadRequest);
        return Ok(result);
    }
}
