using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.CertificateResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CertificateManager : ICertificateService
{
    ICertificateDal _certificateDal;
    IMapper _mapper;
    CertificateBusinessRules _certificateBusinessRules;
    IFileHelper _fileHelper;

    public CertificateManager(ICertificateDal certificateDal, IMapper mapper, CertificateBusinessRules certificateBusinessRules, IFileHelper fileHelper)
    {
        _certificateDal = certificateDal;
        _mapper = mapper;
        _certificateBusinessRules = certificateBusinessRules;
        _fileHelper = fileHelper;
    }

    public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest, string currentPath)
    {
        /* Server */

        #region
        //var uploadResult = _fileHelper.Add(createCertificateRequest.File, currentPath);
        //string newFolderPath = uploadResult.Result.Replace(currentPath, PathConstant.CertificatesPath);
        //createCertificateRequest.FolderPath = newFolderPath;

        //Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
        //Certificate addedCertificate = await _certificateDal.AddAsync(certificate);
        //CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(addedCertificate);
        //return createdCertificateResponse;
        #endregion


        /* Localhost */

        #region

        string folderPath = currentPath.Replace(currentPath, PathConstant.LocalCertificatesPath);
        string addResult = await _fileHelper.Add(createCertificateRequest.File, folderPath);
        string newFolderPath = addResult.Replace(folderPath, PathConstant.LocalBaseUrlCertificatesPath);

        Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
        certificate.FolderPath = newFolderPath;

        Certificate addedCertificate = await _certificateDal.AddAsync(certificate);
        CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(addedCertificate);
        return createdCertificateResponse;

        #endregion
    }

    public async Task<DeletedCertificateResponse> DeleteAsync(Guid id)
    {

        /* Server */

        #region
        //await _certificateBusinessRules.IsExistsCertificate(id);
        //Certificate certificate = await _certificateDal.GetAsync(predicate: l => l.Id == id);
        //await _fileHelper.Delete(certificate.FolderPath.TrimStart('\\'));
        //Certificate deletedCertificate = await _certificateDal.DeleteAsync(certificate);
        //DeletedCertificateResponse deletedCertificateResponse = _mapper.Map<DeletedCertificateResponse>(deletedCertificate);
        //return deletedCertificateResponse;
        #endregion

        /* Localhost */

        #region
        await _certificateBusinessRules.IsExistsCertificate(id);
        Certificate certificate = await _certificateDal.GetAsync(predicate: l => l.Id == id);
        string folderPath = PathConstant.LocalCertificatesPath + certificate.FolderPath.Substring(PathConstant.LocalBaseUrlCertificatesPath.Length);

        await _fileHelper.Delete(folderPath);
        Certificate deletedCertificate = await _certificateDal.DeleteAsync(certificate);
        DeletedCertificateResponse deletedCertificateResponse = _mapper.Map<DeletedCertificateResponse>(deletedCertificate);
        return deletedCertificateResponse;
        #endregion
    }
    public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
    {
        await _certificateBusinessRules.IsExistsCertificate(updateCertificateRequest.Id);
        Certificate certificate = _mapper.Map<Certificate>(updateCertificateRequest);
        Certificate updatedCertificate = await _certificateDal.UpdateAsync(certificate);
        UpdatedCertificateResponse updatedCertificateResponse = _mapper.Map<UpdatedCertificateResponse>(updatedCertificate);
        return updatedCertificateResponse;
    }

    public async Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest)
    {
        var certificate = await _certificateDal.GetListAsync(
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);
        var mappedCertificate = _mapper.Map<Paginate<GetListCertificateResponse>>(certificate);
        return mappedCertificate;
    }

    public async Task<GetCertificateResponse> GetByIdAsync(Guid id)
    {
        var certificate = await _certificateDal.GetAsync(c => c.Id == id);
        var mappedCertificate = _mapper.Map<GetCertificateResponse>(certificate);
        return mappedCertificate;
    }

    public async Task<IPaginate<GetListCertificateResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var certificates = await _certificateDal.GetListAsync(c => c.AccountId == accountId);
        var mappedCertificates = _mapper.Map<Paginate<GetListCertificateResponse>>(certificates);
        return mappedCertificates;
    }
}
