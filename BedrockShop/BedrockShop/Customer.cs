using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
     public class Customer
    {
        #region Fields

        private static int lastCustomerID = 0;

        #endregion

        #region Properties
        [Key]
        public int CustomerID { get; private set; }
        public string Name { get; set; }
        public int SSN { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<OrderHeader> Orders { get; set; }

        #endregion

        #region Constructors

        public Customer()
        {
            CustomerID = ++lastCustomerID;
        }

        #endregion

    }
}
