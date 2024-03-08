using Business.Abstracts;
using Business.Dtos.Requests.CompetenceRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompetenceCategoriesController : ControllerBase
{
    ICompetenceCategoryService _competenceCategoryService;

   
    public CompetenceCategoriesController(ICompetenceCategoryService competenceCategoryService)
    {
        _competenceCategoryService = competenceCategoryService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _competenceCategoryService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _competenceCategoryService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Competences.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateCompetenceCategoryRequest createCompetenceCategoryRequest)
    {
        var result = await _competenceCategoryService.AddAsync(createCompetenceCategoryRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Competences.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCompetenceCategoryRequest deleteCompetenceCategoryRequest)
    {
        var result = await _competenceCategoryService.DeleteAsync(deleteCompetenceCategoryRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Competences.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompetenceCategoryRequest updateCompetenceCategoryRequest)
    {
        var result = await _competenceCategoryService.UpdateAsync(updateCompetenceCategoryRequest);
        return Ok(result);
    }
}
 

