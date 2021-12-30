using System;
using System.Collections.Generic;

#nullable disable

namespace SampleShoppingCartAPI.Models
{
    public partial class ProductInformation
    {
        public ProductInformation()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ModelNumber { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
