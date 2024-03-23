using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductionCompanyRequests;
using Business.Dtos.Responses.ProductionCompanyResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProductionCompanyManager : IProductionCompanyService
{
    IProductionCompanyDal _productionCompanyDal;
    IMapper _mapper;
    ProductionCompanyBusinessRules _productionCompanyBusinessRules;

    public ProductionCompanyManager(IProductionCompanyDal productionCompanyDal, IMapper mapper, ProductionCompanyBusinessRules productionCompanyBusinessRules)
    {
        _productionCompanyDal = productionCompanyDal;
        _mapper = mapper;
        _productionCompanyBusinessRules = productionCompanyBusinessRules;
    }

    public async Task<CreatedProductionCompanyResponse> AddAsync(CreateProductionCompanyRequest createProductionCompanyRequest)
    {
        ProductionCompany productionCompany = _mapper.Map<ProductionCompany>(createProductionCompanyRequest);
        ProductionCompany addedProductionCompany = await _productionCompanyDal.AddAsync(productionCompany);
        CreatedProductionCompanyResponse createdProductionCompanyResponse = _mapper.Map<CreatedProductionCompanyResponse>(addedProductionCompany);
        return createdProductionCompanyResponse;
    }
    public async Task<DeletedProductionCompanyResponse> DeleteAsync(Guid id)
    {
        await _productionCompanyBusinessRules.IsExistsProductionCompany(id);
        ProductionCompany productionCompany = await _productionCompanyDal.GetAsync(predicate: a => a.Id == id);
        ProductionCompany deletedProductionCompany = await _productionCompanyDal.DeleteAsync(productionCompany);
        DeletedProductionCompanyResponse deletedProductionCompanyResponse = _mapper.Map<DeletedProductionCompanyResponse>(deletedProductionCompany);
        return deletedProductionCompanyResponse;
    }

    public async Task<IPaginate<GetListProductionCompanyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var ProductionCompanies = await _productionCompanyDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var mappedProductionCompanies = _mapper.Map<Paginate<GetListProductionCompanyResponse>>(ProductionCompanies);
        return mappedProductionCompanies;
    }
    public async Task<GetProductionCompanyResponse> GetByIdAsync(Guid id)
    {
        var productionCompany = await _productionCompanyDal.GetAsync(p => p.Id == id);
        var mappedProductionCompany = _mapper.Map<GetProductionCompanyResponse>(productionCompany);
        return mappedProductionCompany;
    }

    public async Task<UpdatedProductionCompanyResponse> UpdateAsync(UpdateProductionCompanyRequest updateProductionCompanyRequest)
    {
        await _productionCompanyBusinessRules.IsExistsProductionCompany(updateProductionCompanyRequest.Id);
        ProductionCompany productionCompany = _mapper.Map<ProductionCompany>(updateProductionCompanyRequest);
        ProductionCompany updatedProductionCompany = await _productionCompanyDal.UpdateAsync(productionCompany);
        UpdatedProductionCompanyResponse updatedProductionCompanyResponse = _mapper.Map<UpdatedProductionCompanyResponse>(updatedProductionCompany);
        return updatedProductionCompanyResponse;
    }
}

