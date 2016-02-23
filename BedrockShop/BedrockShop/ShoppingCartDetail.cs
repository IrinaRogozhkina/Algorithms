using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class ShoppingCartDetail
    {
        #region Properties

        public int ShoppingCartDetailID { get; set; }
        public int ShoppingCartID { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }

        #endregion
    }
}
