using System;

namespace Shop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TeduShopDbContext Init();
    }
}