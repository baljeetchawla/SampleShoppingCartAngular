using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShoppingCartAPI.Models
{
    public class ProductModels
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ModelNumber { get; set; }
        public string ImageName { get; set; }
    }
}
