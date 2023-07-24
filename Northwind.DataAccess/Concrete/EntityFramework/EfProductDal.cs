using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    // implement interface to use its methods
    public class EfProductDal : IProductDal
    {
        // get all elements from database and return a list
        public List<Product> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        // get elemets by id from database and return a list
        public Product Get(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }

        // add a product to database
        public void Add(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        // update a product in database
        public void Update(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //context.Products.Add(product);
                context.SaveChanges();
            }
        }

        // delete a product from database
        public void Delete(Product product)
        {
            // delete product
        }
    }
}
