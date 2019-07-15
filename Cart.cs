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
                

                products.Remove(product);
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to remove product.\n");
                Console.WriteLine(e);
            }
        }

    }
}
