﻿using Business.Dtos.Requests.CompetenceResultRequests;
using Business.Dtos.Responses.CompetenceResultResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceResultService
{
    Task<CreatedCompetenceResultResponse> AddAsync(CreateCompetenceResultRequest createCompetenceResultRequest);
    Task<UpdatedCompetenceResultResponse> UpdateAsync(UpdateCompetenceResultRequest updateCompetenceResultRequest);
    Task<DeletedCompetenceResultResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListCompetenceResultResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCompetenceResultResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListCompetenceResultResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);
}