using Business.Abstracts;
using Business.Dtos.Requests.CompetenceRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.CompetenceTestRequests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceTestsController : ControllerBase
    {
        ICompetenceTestService _competenceTestService;

        public CompetenceTestsController(ICompetenceTestService competenceTestService)
        {
            _competenceTestService = competenceTestService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _competenceTestService.GetByIdAsync(id);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _competenceTestService.GetListAsync(pageRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceTests.Get")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCompetenceTestRequest createCompetenceTestRequest)
        {
            var result = await _competenceTestService.AddAsync(createCompetenceTestRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceTests.Get")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCompetenceTestRequest deleteCompetenceTestRequest)
        {
            var result = await _competenceTestService.DeleteAsync(deleteCompetenceTestRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CompetenceTests.Get")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompetenceTestRequest updateCompetenceTestRequest)
        {
            var result = await _competenceTestService.UpdateAsync(updateCompetenceTestRequest);
            return Ok(result);
        }
    }
}

