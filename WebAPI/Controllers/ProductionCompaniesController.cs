using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.ProductionCompanyValidators;
using Business.Dtos.Requests.ProductionCompanyRequests;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductionCompaniesController : ControllerBase
{
    IProductionCompanyService _productionCompanyService;
    public ProductionCompaniesController(IProductionCompanyService productionCompanyService)
    {
        _productionCompanyService = productionCompanyService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productionCompanyService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productionCompanyService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductionCompanies.Get")]
    [CustomValidation(typeof(CreateProductionCompanyRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductionCompanyRequest createProductionCompanyRequest)
    {
        var result = await _productionCompanyService.AddAsync(createProductionCompanyRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductionCompanies.Get")]
    [CustomValidation(typeof(UpdateProductionCompanyRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductionCompanyRequest updateProductionCompanyRequest)
    {
        var result = await _productionCompanyService.UpdateAsync(updateProductionCompanyRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductionCompanies.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProductionCompanyRequest deleteProductionCompanyRequest)
    {
        var result = await _productionCompanyService.DeleteAsync(deleteProductionCompanyRequest);
        return Ok(result);
    }
}

