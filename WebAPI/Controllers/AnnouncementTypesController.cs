using Business.Abstracts;
using Business.Dtos.Requests.AnnouncementTypeRequests;
using Business.Rules.ValidationRules.FluentValidation.AnnouncementTypeValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementTypesController : ControllerBase
{

    IAnnouncementTypeService _announcementTypeService;

    public AnnouncementTypesController(IAnnouncementTypeService announcementTypeService)
    {
        _announcementTypeService = announcementTypeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _announcementTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _announcementTypeService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementTypes.Get")]
    [CustomValidation(typeof(CreateAnnouncementTypeRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementTypeRequest createAnnouncementTypeRequest)
    {
        var result = await _announcementTypeService.AddAsync(createAnnouncementTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementTypes.Get")]
    [CustomValidation(typeof(UpdateAnnouncementTypeRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementTypeRequest updateAnnouncementTypeRequest)
    {
        var result = await _announcementTypeService.UpdateAsync(updateAnnouncementTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AnnouncementTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementTypeRequest deleteAnnouncementTypeRequest)
    {
        var result = await _announcementTypeService.DeleteAsync(deleteAnnouncementTypeRequest);
        return Ok(result);
    }


}
