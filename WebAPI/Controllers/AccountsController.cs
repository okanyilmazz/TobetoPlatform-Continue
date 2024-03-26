using Business.Abstracts;
using Business.Dtos.Requests.AccountRequests;
using Business.Messages;
using Business.Rules.ValidationRules.FluentValidation.AccountValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    IAccountService _accountService;
    public static IWebHostEnvironment _webHostEnvironment;


    public AccountsController(IAccountService accountService, IWebHostEnvironment webHostEnvironment)
    {
        _accountService = accountService;
        _webHostEnvironment = webHostEnvironment;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetStudentBySessionId")]
    public async Task<IActionResult> GetStudentBySessionIdAsync(Guid sessionId)
    {
        var result = await _accountService.GetStudentBySessionIdAsync(sessionId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetInstructorBySessionId")]
    public async Task<IActionResult> GetInstructorBySessionIdAsync(Guid sessionId)
    {
        var result = await _accountService.GetInstructorBySessionIdAsync(sessionId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonIdForLike")]
    public async Task<IActionResult> GetByLessonIdForLikeAsync(Guid lessonId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetByLessonIdForLikeAsync(lessonId, pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramIdForLike")]
    public async Task<IActionResult> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, [FromQuery] PageRequest pageRequest)
    {
        var result = await _accountService.GetByEducationProgramIdForLikeAsync(educationProgramId, pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [CustomValidation(typeof(CreateAccountRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountRequest createAccountRequest)
    {
        var result = await _accountService.AddAsync(createAccountRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [HttpPut("Image")]
    public async Task<IActionResult> UpdateImageAsync([FromForm] UpdateAccountImageRequest updateAccountImageRequest)
    {
        await _accountService.UpdateImageAsync(updateAccountImageRequest);
        return Ok(true);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [HttpPost("Image")]
    public async Task<IActionResult> AddImageAsync([FromForm] CreateAccountImageRequest createAccountImageRequest)
    {
        var currentPath = _webHostEnvironment.ContentRootPath + PathConstant.ImagePath;
        var result = await _accountService.AddImageAsync(createAccountImageRequest, currentPath);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [CustomValidation(typeof(UpdateAccountRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountRequest updateAccountRequest)
    {
        var result = await _accountService.UpdateAsync(updateAccountRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _accountService.DeleteAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Accounts.Get")]
    [HttpDelete("Image/{id}")]
    public async Task<IActionResult> DeleteImageAsync([FromRoute] Guid id)
    {
        var result = await _accountService.DeleteImageAsync(id);
        return Ok(result);
    }
}
