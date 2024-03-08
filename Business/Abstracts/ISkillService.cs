﻿using Business.Dtos.Requests.SkillRequests;
using Business.Dtos.Responses.SkillResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISkillService
{
    Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest);
    Task<DeletedSkillResponse> DeleteAsync(DeleteSkillRequest deleteSkillRequest);
    Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest);
    Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListSkillResponse>> GetByAccountIdAsync(Guid id);
    Task<GetListSkillResponse> GetByIdAsync(Guid id);

}
