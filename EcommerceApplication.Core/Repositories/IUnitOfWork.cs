using EcommerceApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Address> Address { get; }
        IBaseRepository<Cart> Carts { get; }
        IBaseRepository<CartStatues> CartStatues { get; }
        IBaseRepository<Country> Countries { get; }
        IBaseRepository<OrderDetials> OrderDetails { get; }
        IBaseRepository<OrderTable> OrderTables { get; }
        IBaseRepository<Review> Reviews { get; }

        int Complete();
    }
}
