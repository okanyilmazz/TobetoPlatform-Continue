using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.ContactValidators;
using Business.Rules.ValidationRules.FluentValidation.DegreeTypeValidators;
using Business.Dtos.Requests.DegreeTypeRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DegreeTypesController : ControllerBase
{

    IDegreeTypeService _degreeTypeService;

    public DegreeTypesController(IDegreeTypeService degreeTypeservice)
    {
        _degreeTypeService = degreeTypeservice;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _degreeTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _degreeTypeService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("DegreeTypes.Get")]
    [CustomValidation(typeof(CreateDegreeTypeRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateDegreeTypeRequest createDegreeTypeRequest)
    {
        var result = await _degreeTypeService.AddAsync(createDegreeTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("DegreeTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteDegreeTypeRequest deleteDegreeTypeRequest)
    {
        var result = await _degreeTypeService.DeleteAsync(deleteDegreeTypeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("DegreeTypes.Get")]
    [CustomValidation(typeof(UpdateContactRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateDegreeTypeRequest updateDegreeTypeRequest)
    {
        var result = await _degreeTypeService.UpdateAsync(updateDegreeTypeRequest);
        return Ok(result);
    }
}

