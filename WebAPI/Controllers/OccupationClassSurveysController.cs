﻿using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.OccupationClassSurveyValidators;
using Business.Dtos.Requests.OccupationClassSurveyRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OccupationClassSurveysController : ControllerBase
{
    IOccupationClassSurveyService _occupationClassSurveyService;

    public OccupationClassSurveysController(IOccupationClassSurveyService occupationClassSurveyService)
    {
        _occupationClassSurveyService = occupationClassSurveyService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _occupationClassSurveyService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _occupationClassSurveyService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClassSurveys.Get")]
    [CustomValidation(typeof(CreateOccupationClassSurveyRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateOccupationClassSurveyRequest createOccupationClassSurveyRequest)
    {
        var result = await _occupationClassSurveyService.AddAsync(createOccupationClassSurveyRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClassSurveys.Get")]
    [CustomValidation(typeof(UpdateOccupationClassSurveyRequestValidator))]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteOccupationClassSurveyRequest deleteOccupationClassSurveyRequest)
    {
        var result = await _occupationClassSurveyService.DeleteAsync(deleteOccupationClassSurveyRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("OccupationClassSurveys.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateOccupationClassSurveyRequest updateOccupationClassSurveyRequest)
    {
        var result = await _occupationClassSurveyService.UpdateAsync(updateOccupationClassSurveyRequest);
        return Ok(result);
    }
}
