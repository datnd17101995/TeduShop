using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IErrorsRepository : IRepository<Error>
    {

    }
    public class ErrorsRepository : RepositoryBase<Error>,IErrorsRepository
    {
        public ErrorsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
