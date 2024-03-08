using System;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Responses.ProductionCompanyResponses;
using Business.Dtos.Requests.ProductionCompanyRequests;

namespace Business.Abstracts
{
    public interface IProductionCompanyService
    {
        Task<CreatedProductionCompanyResponse> AddAsync(CreateProductionCompanyRequest createProductionCompanyRequest);
        Task<UpdatedProductionCompanyResponse> UpdateAsync(UpdateProductionCompanyRequest updateProductionCompanyRequest);
        Task<DeletedProductionCompanyResponse> DeleteAsync(DeleteProductionCompanyRequest deleteProductionCompanyRequest);
        Task<IPaginate<GetListProductionCompanyResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListProductionCompanyResponse> GetByIdAsync(Guid id);
    }
}
