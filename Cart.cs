using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce
{
    /// <summary>
    /// shopping cart class
    /// </summary>
    public class Cart
    {
        private int cartID, userID;
        private List<Product> products; // could probably use something a bit less resource intensive

        /// <summary>
        /// constructor. fills out userID and cartID. cartID default value should be dynamic, but
        /// since there is nowhere to get a running cartID number from, i will leave it hardcoded...
        /// </summary>
        /// <param name="userID"> userID that owns this cart </param>
        /// <param name="cartID"> cartID of this cart </param>
        public Cart(int UID, int CID = 0)
        {
            try
            {
                // IDs cant be negative
                if (CID < 0 | UID < 0) throw new IndexOutOfRangeException();
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong instantiating Cart.");
                Console.WriteLine(e);

                Console.WriteLine("default params used to create cart instead");

                // defaults could be set dynamically, instead of hardcoded
                // as hardcoded default kinda defeats purpose of userID/cartID relationship
                CID = -1;
                UID = -1;
            }
            finally
            {
                this.cartID = CID;
                this.userID = UID;
                products = new List<Product>();
            }
        }

        /// <summary>
        /// destructor. nothing to destruct since GC takes care of everything used so far...
        /// </summary>
        ~Cart()
        {

        }

        /// <summary>
        /// add product to this cart
        /// </summary>
        /// <param name="product"> product to add to this cart </param>
        public void addProduct(Product product)
        {
            try
            {
                // product cant be null
                if (product == null) throw new ArgumentNullException(); // cant have null product added


                products.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to add product.\n");
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// removes 1st occurrence of specified product
        /// </summary>
        /// <param name="product"> product to remove from cart </param>
        public void removeProduct(Product product)
        {
            try
            { 
                
                foreach (Product pd in products)
                {
                    if (pd.productID == product.productID)
                    {
                        products.Remove(pd);
                        break;
                    }
                }
                

                Console.WriteLine("unable to remove product. product is not in cart");
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to remove product.\n");
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// returns sum of products in this cart
        /// </summary>
        /// <returns> sum of products in this cart </returns>
        public int numberOfProducts()
        {
            // no need for error handling since list cant be set to null and is always
            // initialised at construction

            return products.Count;
        }

        /// <summary>
        /// returns current products
        /// </summary>
        /// <returns> products stored in this cart </returns>
        public List<Product> GetProducts()
        {
            // no need for error handling since list is always initialised

            return new List<Product>(products);
        }

        /// <summary>
        /// returns a string representing contents of cart
        /// </summary>
        /// <returns> a string that represents contents of cart, including cart ID and user ID </returns>
        public string cartInfoInString()
        {
            // no need for error handling since assertions on functions prevent addition of erroneous data


            string str = "", tab = "\t|";    // str = output
            int sum = numberOfProducts();   // in case more products added/removed before this task completes fully


            str += "Cart ID: " + cartID + "\nUser ID of Cart: " + userID + "\nItems In Cart: " + sum;
            str += "\nItems:" +
                   "\n\n\tNumber\t|PID\t|Name";
            str += "\n\t........|.......|..........................................................\n";

            int i = 1;

            // add each product
            foreach (Product product in products)
            {
                str += "\t" + i + tab + product.productID + tab + product.name + "\n";
                i++;
            }


            return str + "\n- end of cart -";

        }




    }
}
