using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ManagementProgramRequests;
using Business.Dtos.Responses.ManagementProgramResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ManagementProgramManager : IManagementProgramService
{

    IManagementProgramDal _managementProgramDal;
    IMapper _mapper;
    ManagementProgramBusinessRules _managementProgramBusinessRules;

    public ManagementProgramManager(ManagementProgramBusinessRules managementProgramBusinessRules, IMapper mapper, IManagementProgramDal managementProgramDal)
    {
        _managementProgramBusinessRules = managementProgramBusinessRules;
        _mapper = mapper;
        _managementProgramDal = managementProgramDal;
    }
    public async Task<CreatedManagementProgramResponse> AddAsync(CreateManagementProgramRequest createManagementProgramRequest)
    {
        ManagementProgram managementProgram = _mapper.Map<ManagementProgram>(createManagementProgramRequest);
        ManagementProgram addedManagementProgram = await _managementProgramDal.AddAsync(managementProgram);
        var mappedManagementProgram = _mapper.Map<CreatedManagementProgramResponse>(addedManagementProgram);
        return mappedManagementProgram;
    }

    public async Task<DeletedManagementProgramResponse> DeleteAsync(Guid id)
    {
        await _managementProgramBusinessRules.IsExistsManagementProgram(id);
        ManagementProgram managementProgram = await _managementProgramDal.GetAsync(predicate: m => m.Id == id);
        ManagementProgram deletedManagementProgram = await _managementProgramDal.DeleteAsync(managementProgram);
        var mappedManagementProgram = _mapper.Map<DeletedManagementProgramResponse>(deletedManagementProgram);
        return mappedManagementProgram;
    }

    public async Task<GetManagementProgramResponse> GetByIdAsync(Guid id)
    {
        var managementProgram = await _managementProgramDal.GetAsync(l => l.Id == id);
        var mappedManagementProgram = _mapper.Map<GetManagementProgramResponse>(managementProgram);
        return mappedManagementProgram;
    }

    public async Task<IPaginate<GetListManagementProgramResponse>> GetListAsync(PageRequest pageRequest)
    {
        var managementProgramList = await _managementProgramDal.GetListAsync(index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedManagementProgram = _mapper.Map<Paginate<GetListManagementProgramResponse>>(managementProgramList);
        return mappedManagementProgram;
    }

    public async Task<UpdatedManagementProgramResponse> UpdateAsync(UpdateManagementProgramRequest updateManagementProgramRequest)
    {
        await _managementProgramBusinessRules.IsExistsManagementProgram(updateManagementProgramRequest.Id);
        ManagementProgram managementProgram = _mapper.Map<ManagementProgram>(updateManagementProgramRequest);
        ManagementProgram updateedManagementProgram = await _managementProgramDal.UpdateAsync(managementProgram);
        var mappedManagementProgram = _mapper.Map<UpdatedManagementProgramResponse>(updateedManagementProgram);
        return mappedManagementProgram;
    }
}
