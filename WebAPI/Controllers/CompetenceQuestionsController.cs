using Business.Abstracts;
using Business.Dtos.Requests.CompetenceQuestionRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceQuestionsController : ControllerBase
    {
        ICompetenceQuestionService _competenceQuestionService;

        public CompetenceQuestionsController(ICompetenceQuestionService competenceQuestionService)
        {
            _competenceQuestionService = competenceQuestionService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _competenceQuestionService.GetByIdAsync(id);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _competenceQuestionService.GetListAsync(pageRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceQuestions.Get")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCompetenceQuestionRequest createCompetenceQuestionRequest)
        {
            var result = await _competenceQuestionService.AddAsync(createCompetenceQuestionRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceQuestions.Get")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCompetenceQuestionRequest deleteCompetenceQuestionRequest)
        {
            var result = await _competenceQuestionService.DeleteAsync(deleteCompetenceQuestionRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceQuestions.Get")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompetenceQuestionRequest updateCompetenceQuestionRequest)
        {
            var result = await _competenceQuestionService.UpdateAsync(updateCompetenceQuestionRequest);
            return Ok(result);
        }
    }
}
 