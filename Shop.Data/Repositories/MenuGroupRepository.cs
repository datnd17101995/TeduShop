using Shop.Data.Infrastructure;
using Shop.Model.Models;

namespace Shop.Data.Repositories
{
    public interface IMenuGroupRepository : IRepository<MenuGroups>
    {
    }

    public class MenuGroupRepository : RepositoryBase<MenuGroups>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}