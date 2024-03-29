﻿using Business.Dtos.Requests.CompetenceTestQuestionRequests;
using Business.Dtos.Responses.CompetenceTestQuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceTestQuestionService
{
    Task<CreatedCompetenceTestQuestionResponse> AddAsync(CreateCompetenceTestQuestionRequest createCompetenceTestQuestionRequest);
    Task<UpdatedCompetenceTestQuestionResponse> UpdateAsync(UpdateCompetenceTestQuestionRequest updateCompetenceTestQuestionRequest);
    Task<DeletedCompetenceTestQuestionResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListCompetenceTestQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCompetenceTestQuestionResponse> GetByIdAsync(Guid id);
}
