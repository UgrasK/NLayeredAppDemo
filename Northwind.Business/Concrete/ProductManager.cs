﻿using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
