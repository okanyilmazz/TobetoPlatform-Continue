﻿using Business.Dtos.Requests.EducationProgramOccupationClassRequests;
using Business.Dtos.Responses.EducationProgramOccupationClassResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramOccupationClassService
{
    Task<CreatedEducationProgramOccupationClassResponse> AddAsync(CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest);
    Task<UpdatedEducationProgramOccupationClassResponse> UpdateAsync(UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest);
    Task<DeletedEducationProgramOccupationClassResponse> DeleteAsync(DeleteEducationProgramOccupationClassRequest deleteEducationProgramOccupationClassRequest);
    Task<IPaginate<GetListEducationProgramOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListEducationProgramOccupationClassResponse> GetByIdAsync(Guid id);
}
