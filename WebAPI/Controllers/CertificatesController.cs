using Business.Abstracts;
using Business.Dtos.Requests.CertificateRequests;
using Business.Messages;
using Business.Rules.ValidationRules.FluentValidation.CertificateValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : Controller
{
    ICertificateService _certificateService;
    public static IWebHostEnvironment _webHostEnvironment;

    public CertificatesController(ICertificateService certificateService, IWebHostEnvironment webHostEnvironment)
    {
        _certificateService = certificateService;
        _webHostEnvironment = webHostEnvironment;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _certificateService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _certificateService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Certificates.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm]CreateCertificateRequest createCertificateRequest)
    {
        var currentPath = _webHostEnvironment.ContentRootPath + PathConstant.CertificatesPath;
        var result = await _certificateService.AddAsync(createCertificateRequest,currentPath);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Certificates.Get")]
    [CustomValidation(typeof(UpdateCertificateRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCertificateRequest updateCertificateRequest)
    {
        var result = await _certificateService.UpdateAsync(updateCertificateRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Certificates.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _certificateService.DeleteAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid accountId)
    {
        var result = await _certificateService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }
}

