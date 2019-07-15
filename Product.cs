using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce
{
    /// <summary>
    /// placeholder class. exists to demonstrate that Cart class will contain a list of these (product)
    /// </summary>
    public class Product
    {
        // public for now since this is out of the scope of the project and only
        // for demonstrative purposes
        public int productID;
        public string name;
        public Product(int id = 123, string name = "product name")
        {
            productID = id;
            this.name = name;
        }
    }
}
