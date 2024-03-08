﻿using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramSubjectRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramSubjectsController : ControllerBase
{
    IEducationProgramSubjectService _educationProgramSubjectService;

    public EducationProgramSubjectsController(IEducationProgramSubjectService educationProgramSubjectService)
    {
        _educationProgramSubjectService = educationProgramSubjectService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramSubjectService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramSubjectService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramSubjectRequest createEducationProgramSubjectRequest)
    {
        var result = await _educationProgramSubjectService.AddAsync(createEducationProgramSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramSubjectRequest updateEducationProgramSubjectRequest)
    {
        var result = await _educationProgramSubjectService.UpdateAsync(updateEducationProgramSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramSubjects.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramSubjectRequest deleteEducationProgramSubjectRequest)
    {
        var result = await _educationProgramSubjectService.DeleteAsync(deleteEducationProgramSubjectRequest);
        return Ok(result);
    }

}
