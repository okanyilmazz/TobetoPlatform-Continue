﻿using Business.Dtos.Requests.OccupationRequests;
using Business.Dtos.Responses.OccupationResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IOccupationService
{

    Task<CreatedOccupationResponse> AddAsync(CreateOccupationRequest createOccupationRequest);
    Task<UpdatedOccupationResponse> UpdateAsync(UpdateOccupationRequest updateOccupationRequest);
    Task<DeletedOccupationResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListOccupationResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetOccupationResponse> GetByIdAsync(Guid Id);
}
