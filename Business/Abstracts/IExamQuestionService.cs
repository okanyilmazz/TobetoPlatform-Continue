﻿using Business.Dtos.Requests.ExamQuestionRequests;
using Business.Dtos.Responses.ExamQuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamQuestionService
	{
    Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest);
    Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest);
    Task<DeletedExamQuestionResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListExamQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetExamQuestionResponse> GetByIdAsync(Guid id);
}