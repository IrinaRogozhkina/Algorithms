using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class OrderDetail
    {
        #region Properties
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderHeaderID { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }

        #endregion


    }
}
