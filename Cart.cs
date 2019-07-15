using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce
{
    /// <summary>
    /// shopping cart class
    /// </summary>
    class Cart
    {
        private int cartID, userID;
        private List<Product> products; // could probably use something a bit less resource intensive

        /// <summary>
        /// constructor. fills out userID and cartID. cartID default value should be dynamic, but
        /// since there is nowhere to get a running cartID number from, i will leave it hardcoded...
        /// </summary>
        /// <param name="userID"> userID that owns this cart </param>
        /// <param name="cartID"> cartID of this cart </param>
        public Cart(int userID, int cartID = 0)
        {
            this.cartID = cartID;
            this.userID = userID;
            products = new List<Product>();
        }


        /// <summary>
        /// destructor. nothing to destruct since GC takes care of everything used so far...
        /// </summary>
        ~Cart()
        {

        }




    }
}
