using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class BlogImageBusinessRules : BaseBusinessRules
{
    private readonly IBlogImageDal _blogImageDal;

    public BlogImageBusinessRules(IBlogImageDal blogImageDal)
    {
        _blogImageDal = blogImageDal;
    }

    public async Task IsExistsBlogImage(Guid blogImageId)
    {
        var result = await _blogImageDal.GetAsync(
            predicate: b => b.Id == blogImageId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
