using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class OrderHeader
    {
        #region Properties
        [Key]
        public int OrderHeaderID { get; set; }

        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Customer Customer { get; set; }

        #endregion
    }
}
