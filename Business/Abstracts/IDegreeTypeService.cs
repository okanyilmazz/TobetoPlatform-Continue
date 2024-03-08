using Business.Dtos.Requests.DegreeTypeRequests;
using Business.Dtos.Responses.DegreeTypeResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IDegreeTypeService
    {
        Task<CreatedDegreeTypeResponse> AddAsync(CreateDegreeTypeRequest creatDegreeTypeRequest);
        Task<DeletedDegreeTypeResponse> DeleteAsync(DeleteDegreeTypeRequest deleteDegreeTypeRequest);
        Task<UpdatedDegreeTypeResponse> UpdateAsync(UpdateDegreeTypeRequest updateDegreeTypeRequest);

        Task<IPaginate<GetListDegreeTypeResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListDegreeTypeResponse> GetByIdAsync(Guid id);

    }
}
