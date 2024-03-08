using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AddressRequests;
using Business.Dtos.Responses.AddressResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AddressManager : IAddressService
{
    IAddressDal _addressDal;
    IMapper _mapper;
    AddressBusinessRules _addressBusinessRules;

    public AddressManager(IAddressDal addressDal, IMapper mapper, AddressBusinessRules addressBusinessRules)
    {
        _addressDal = addressDal;
        _mapper = mapper;
        _addressBusinessRules = addressBusinessRules;
    }

    public async Task<CreatedAddressResponse> AddAsync(CreateAddressRequest createAddressRequest)
    {
        Address address = _mapper.Map<Address>(createAddressRequest);
        Address createdAddress = await _addressDal.AddAsync(address);
        CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(createdAddress);
        return createdAddressResponse;
    }

    public async Task<DeletedAddressResponse> DeleteAsync(DeleteAddressRequest deleteAddressRequest)
    {
        await _addressBusinessRules.IsExistsAdress(deleteAddressRequest.Id);
        Address address = await _addressDal.GetAsync(predicate: l => l.Id == deleteAddressRequest.Id);
        Address deletedAddress = await _addressDal.DeleteAsync(address);
        DeletedAddressResponse deletedAddressResponse = _mapper.Map<DeletedAddressResponse>(deletedAddress);
        return deletedAddressResponse;
    }

    public async Task<GetListAddressResponse> GetByIdAsync(Guid Id)
    {
        var addresss = await _addressDal.GetAsync(
            predicate: a => a.Id == Id,
            include: a => a
            .Include(a => a.District)
            .Include(a => a.City)
            .Include(a => a.Country));
        var mappedAddresses = _mapper.Map<GetListAddressResponse>(addresss);
        return mappedAddresses;
    }

    public async Task<GetListAddressResponse> GetByAccountIdAsync(Guid accountId)
    {
        var accountAddress = await _addressDal.GetAsync(
            predicate: a => a.AccountId == accountId);
        var mappedAccountAddress = _mapper.Map<GetListAddressResponse>(accountAddress);
        return mappedAccountAddress;
    }

    public async Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest)
    {
        var address = await _addressDal.GetListAsync(
            include: a => a
            .Include(a => a.District)
            .Include(a => a.City)
            .Include(a => a.Country),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedAddresses = _mapper.Map<Paginate<GetListAddressResponse>>(address);
        return mappedAddresses;
    }

    public async Task<UpdatedAddressResponse> UpdateAsync(UpdateAddressRequest updateAddressRequest)
    {
        Address address = _mapper.Map<Address>(updateAddressRequest);
        Address updatedAddress = await _addressDal.UpdateAsync(address);
        UpdatedAddressResponse updatedAddressResponse = _mapper.Map<UpdatedAddressResponse>(updatedAddress);
        return updatedAddressResponse;
    }
}
