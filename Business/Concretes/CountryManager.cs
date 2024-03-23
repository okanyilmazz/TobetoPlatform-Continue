using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CountryRequests;
using Business.Dtos.Responses.CountryResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CountryManager : ICountryService
{
    ICountryDal _countryDal;
    IMapper _mapper;
    CountryBusinessRules _countryBusinessRules;

    public CountryManager(ICountryDal countryDal, IMapper mapper, CountryBusinessRules countryBusinessRules)
    {
        _countryDal = countryDal;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<CreatedCountryResponse> AddAsync(CreateCountryRequest createCountryRequest)
    {
        Country country = _mapper.Map<Country>(createCountryRequest);
        Country addedCountry = await _countryDal.AddAsync(country);
        var responseCountry = _mapper.Map<CreatedCountryResponse>(addedCountry);
        return responseCountry;
    }

    public async Task<DeletedCountryResponse> DeleteAsync(Guid id)
    {
        await _countryBusinessRules.IsExistsCountry(id);
        Country country = await _countryDal.GetAsync(predicate: c => c.Id == id);
        Country deletedCountry = await _countryDal.DeleteAsync(country);
        DeletedCountryResponse deletedCountryResponse = _mapper.Map<DeletedCountryResponse>(deletedCountry);
        return deletedCountryResponse;
    }

    public async Task<GetCountryResponse> GetByIdAsync(Guid id)
    {
        var country = await _countryDal.GetAsync(c => c.Id == id);
        var mappedCountry = _mapper.Map<GetCountryResponse>(country);
        return mappedCountry;
    }

    public async Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var Countries = await _countryDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedCountries = _mapper.Map<Paginate<GetListCountryResponse>>(Countries);
        return mappedCountries;
    }

    public async Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest updateCountryRequest)
    {
        await _countryBusinessRules.IsExistsCountry(updateCountryRequest.Id);
        Country country = _mapper.Map<Country>(updateCountryRequest);
        Country updatedCountry = await _countryDal.UpdateAsync(country);
        UpdatedCountryResponse updatedCountryResponse = _mapper.Map<UpdatedCountryResponse>(updatedCountry);
        return updatedCountryResponse;
    }
}

