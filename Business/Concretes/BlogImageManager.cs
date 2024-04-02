using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.BlogImageRequests;
using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.BlogImageResponses;
using Business.Dtos.Responses.CertificateResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BlogImageManager : IBlogImageService
    {
        IBlogImageDal _blogImageDal;
        IMapper _mapper;
        BlogImageBusinessRules _blogImageBusinessRules;
        IFileHelper _fileHelper;

        public BlogImageManager(IBlogImageDal blogImageDal, IMapper mapper, IFileHelper fileHelper, BlogImageBusinessRules blogImageBusinessRules)

        {
            _blogImageDal = blogImageDal;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _blogImageBusinessRules = blogImageBusinessRules;
        }



        public async Task<UpdatedBlogImageResponse> UpdateAsync(UpdateBlogImageRequest updateBlogImageRequest)
        {
            await _blogImageBusinessRules.IsExistsBlogImage(updateBlogImageRequest.Id);

            /* Server */

            #region
            //BlogImage blogImage = await _blogImageDal.GetAsync(predicate: a => a.Id == updateBlogImageRequest.Id);
            //string newBlogThumbnailPath = await _fileHelper.Update(updateBlogImageRequest.File, blogImage.ImagePath);
            //blogImage.ImagePath = newBlogThumbnailPath;
            //await _blogImageDal.UpdateAsync(blog);
            //var mappedBlogImage = _mapper.Map<UpdatedBlogImageResponse>(blogImage);
            //return mappedBlogImage;
            #endregion

            /* Localhost */

            #region
            BlogImage blogImage = await _blogImageDal.GetAsync(predicate: a => a.Id == updateBlogImageRequest.Id);
            string blogThumbnailPath = blogImage.ImagePath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
            string newFolderPathForLocal = PathConstant.LocalImagePath + blogThumbnailPath;
            string newBlogThumbnailPath = await _fileHelper.Update(updateBlogImageRequest.File, newFolderPathForLocal);
            string newThumbnailLocalPath = newBlogThumbnailPath.Replace(PathConstant.LocalImagePath, PathConstant.LocalBaseUrlImagePath);

            blogImage.ImagePath = newThumbnailLocalPath;
            await _blogImageDal.UpdateAsync(blogImage);
            var mappedBlogImage = _mapper.Map<UpdatedBlogImageResponse>(blogImage);
            return mappedBlogImage;
            #endregion
        }

        public async Task<CreatedBlogImageResponse> AddAsync(CreateBlogImageRequest createBlogImageRequest, string currentPath)
        {

            /* Server */

            #region
            //var uploadResult = _fileHelper.Add(createBlogImageRequest.File, currentPath);
            //string newFolderPath = uploadResult.Result.Replace(currentPath, PathConstant.ImagePath);
            //BlogImage blogImage = _mapper.Map<BlogImage>(createBlogImageRequest);
            //blogImage.ImagePath = newFolderPath;

            //BlogImage addedBlogImage = await _blogImageDal.AddAsync(blogImage);
            //CreatedBlogImageResponse createdBlogImageResponse = _mapper.Map<CreatedBlogImageResponse>(addedBlogImage);
            //return createdBlogImageResponse;
            #endregion

            /* Localhost */

            #region
            string folderPath = currentPath.Replace(currentPath, PathConstant.LocalImagePath);
            string addResult = await _fileHelper.Add(createBlogImageRequest.File, folderPath);
            string newFolderPath = addResult.Replace(folderPath, PathConstant.LocalBaseUrlImagePath);

            BlogImage blogImage = _mapper.Map<BlogImage>(createBlogImageRequest);
            blogImage.ImagePath = newFolderPath;

            BlogImage addedBlogImage = await _blogImageDal.AddAsync(blogImage);
            CreatedBlogImageResponse createdBlogImageResponse = _mapper.Map<CreatedBlogImageResponse>(addedBlogImage);
            return createdBlogImageResponse;
            #endregion
        }

        public async Task<DeletedBlogImageResponse> DeleteAsync(Guid id)
        {
            /* Server */

            #region
            //await _blogImageBusinessRules.IsExistsBlog(id);
            //BlogImage blogImage = await _blogImageDal.GetAsync(predicate: l => l.Id == id);
            //await _fileHelper.Delete(blogImage.ImagePath);
            //blogImage.ImagePath = null;
            //BlogImage deletedBlogImage = await _blogImageDal.UpdateAsync(blogImage);
            //DeletedBlogResponse deletedBlogResponse = _mapper.Map<DeletedBlogResponse>(deletedBlogImage);
            //return deletedBlogResponse;
            #endregion

            /* Localhost */

            #region
            await _blogImageBusinessRules.IsExistsBlogImage(id);
            BlogImage blogImage = await _blogImageDal.GetAsync(predicate: l => l.Id == id);
            string imagePath = PathConstant.LocalImagePath + blogImage.ImagePath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
            await _fileHelper.Delete(imagePath);
            blogImage.ImagePath = null;
            BlogImage deletedBlogImage = await _blogImageDal.UpdateAsync(blogImage);
            DeletedBlogImageResponse deletedBlogImageResponse = _mapper.Map<DeletedBlogImageResponse>(deletedBlogImage);
            return deletedBlogImageResponse;
            #endregion
        }

        public async Task<GetBlogImageResponse> GetByIdAsync(Guid id)
        {
            var blogImage = await _blogImageDal.GetAsync(b => b.Id == id);
            var mappedBlogImage = _mapper.Map<GetBlogImageResponse>(blogImage);
            return mappedBlogImage;
        }

        public async Task<GetBlogImageResponse> GetByBlogIdAsync(Guid blogId)
        {
            var blogImage = await _blogImageDal.GetAsync(b => b.BlogId == blogId);
            var mappedBlogImage = _mapper.Map<GetBlogImageResponse>(blogImage);
            return mappedBlogImage;
        }

        public async Task<IPaginate<GetListBlogImageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var blogImages = await _blogImageDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
            var mappedBlogImages = _mapper.Map<Paginate<GetListBlogImageResponse>>(blogImages);
            return mappedBlogImages;
        }
    }
}
