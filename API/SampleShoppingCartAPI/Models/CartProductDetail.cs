using System;
using System.Collections.Generic;

#nullable disable

namespace SampleShoppingCartAPI.Models
{
    public partial class CartProductDetail
    {
        public int CartProductDetailsId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public virtual UserInformation User { get; set; }
    }
}
