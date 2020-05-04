using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IRepository
    {

        IEnumerable<Product> Products { get; }
        void AddProduct(Product p);
    }
}