using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class ShoppingCart
    {
        #region Properties

        [Key]
        public int ShoppingCartID { get; set; }

        public decimal SubTotal { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
