using System;
using System.Collections.Generic;

#nullable disable

namespace SampleShoppingCartAPI.Models
{
    public partial class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }

        public virtual ProductInformation Product { get; set; }
    }
}
