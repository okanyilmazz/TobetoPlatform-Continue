using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IAccountLanguageDal : IRepository<AccountLanguage, Guid>, IAsyncRepository<AccountLanguage, Guid>
    {
    }
}