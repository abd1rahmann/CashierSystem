﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSASYSTEM2
{
    public class Product
    {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int ProductID { get; set; }
            public string PriceType { get; set; }

        //public Product (string name, decimal price, int productID)
        //{
        //    Name = name;
        //    Price = price;
        //    ProductID = productID;
        //    PriceType = PriceType;
        //}

    }
}
