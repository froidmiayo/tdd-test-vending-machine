using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public Product(ProductType t, decimal p)
        {
            Type = t;
            Price = p;
        }
        public  ProductType Type { get; set; }
        public  decimal Price { get; set; }
    }
    public enum ProductType
    {
        Coke,Pepsi,Soda,ChocolateBar,ChewingGum,BottledWater
    }
}
