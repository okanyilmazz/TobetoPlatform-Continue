using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.UniversityDepartmentValidators;
using Business.Dtos.Requests.UniversityDepartmentRequests;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityDepartmentsController : Controller
{
    IUniversityDepartmentService _universityDepartmentService;

    public UniversityDepartmentsController(IUniversityDepartmentService universityDepartmentService)
    {
        _universityDepartmentService = universityDepartmentService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _universityDepartmentService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _universityDepartmentService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("UniversityDepartments.Get")]
    [CustomValidation(typeof(CreateUniversityDepartmentRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateUniversityDepartmentRequest createUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.AddAsync(createUniversityDepartmentRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("UniversityDepartments.Get")]
    [CustomValidation(typeof(UpdateUniversityDepartmentRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.UpdateAsync(updateUniversityDepartmentRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("UniversityDepartments.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.DeleteAsync(deleteUniversityDepartmentRequest);
        return Ok(result);
    }
}