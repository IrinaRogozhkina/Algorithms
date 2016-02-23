using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    /// <summary>
    /// This is the shopping item
    /// Describes the item
    /// </summary>
    public class Product
    {
        #region Properties
        /// <summary>
        /// ID of the item
        /// </summary>
        [Key]
        public int ProductID { get; set; }
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Image { get; set; }
        #endregion

    }
}
