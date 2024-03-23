using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.CompetenceTestQuestionRequests;
using Core.DataAccess.Paging;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompetenceTestQuestionsController : ControllerBase
{
    ICompetenceTestQuestionService _competenceTestQuestionService;

    public CompetenceTestQuestionsController(ICompetenceTestQuestionService competenceTestQuestionService)
    {
        _competenceTestQuestionService = competenceTestQuestionService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _competenceTestQuestionService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _competenceTestQuestionService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("CompetenceTestQuestions.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateCompetenceTestQuestionRequest createCompetenceTestQuestionRequest)
    {
        var result = await _competenceTestQuestionService.AddAsync(createCompetenceTestQuestionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("CompetenceTestQuestions.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompetenceTestQuestionRequest updateCompetenceTestQuestionRequest)
    {
        var result = await _competenceTestQuestionService.UpdateAsync(updateCompetenceTestQuestionRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("CompetenceTestQuestions.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _competenceTestQuestionService.DeleteAsync(id);
        return Ok(result);
    }
}
