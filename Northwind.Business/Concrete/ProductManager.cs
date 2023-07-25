using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using Northwind.Business.Utilities;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        
        private IProductDal _productDal;
        
        // create a ProductManager object with IProductDal parameter 
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        

        // get all products as List & return them
        public List<Product> GetAll()
        {
            //Business code
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p=> p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
