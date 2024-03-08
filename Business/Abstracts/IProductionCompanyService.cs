using Business.Dtos.Requests.ProductionCompanyRequests;
using Business.Dtos.Responses.ProductionCompanyResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductionCompanyService
{
    Task<CreatedProductionCompanyResponse> AddAsync(CreateProductionCompanyRequest createProductionCompanyRequest);
    Task<UpdatedProductionCompanyResponse> UpdateAsync(UpdateProductionCompanyRequest updateProductionCompanyRequest);
    Task<DeletedProductionCompanyResponse> DeleteAsync(DeleteProductionCompanyRequest deleteProductionCompanyRequest);
    Task<IPaginate<GetListProductionCompanyResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductionCompanyResponse> GetByIdAsync(Guid id);
}
