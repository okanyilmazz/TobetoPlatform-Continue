using Business.Abstracts;
using Business.Dtos.Requests.CompetenceRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.CompetenceResultRequests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceResultsController : ControllerBase
    {
        ICompetenceResultService _competenceResultService;

        public CompetenceResultsController(ICompetenceResultService competenceResultService)
        {
            _competenceResultService = competenceResultService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _competenceResultService.GetByIdAsync(id);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _competenceResultService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetByAccountId")]
        public async Task<IActionResult> GetByAccountIdAsync([FromQuery] PageRequest pageRequest, Guid accountId)
        {
            var result = await _competenceResultService.GetByAccountIdAsync(accountId, pageRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceResults.Get")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCompetenceResultRequest createCompetenceResultRequest)
        {
            var result = await _competenceResultService.AddAsync(createCompetenceResultRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceResults.Get")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCompetenceResultRequest deleteCompetenceResultRequest)
        {
            var result = await _competenceResultService.DeleteAsync(deleteCompetenceResultRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceResults.Get")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompetenceResultRequest updateCompetenceResultRequest)
        {
            var result = await _competenceResultService.UpdateAsync(updateCompetenceResultRequest);
            return Ok(result);
        }
    }
}

