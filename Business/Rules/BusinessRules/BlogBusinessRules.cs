using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class BlogBusinessRules : BaseBusinessRules
{
    private readonly IBlogDal _blogDal;

    public BlogBusinessRules(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public async Task IsExistsBlog(Guid blogId)
    {
        var result = await _blogDal.GetAsync(
            predicate: b => b.Id == blogId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}