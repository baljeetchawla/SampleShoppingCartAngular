using System;
using System.Collections.Generic;

#nullable disable

namespace SampleShoppingCartAPI.Models
{
    public partial class UserInformation
    {
        public UserInformation()
        {
            CartInformations = new HashSet<CartInformation>();
            CartProductDetails = new HashSet<CartProductDetail>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<CartInformation> CartInformations { get; set; }
        public virtual ICollection<CartProductDetail> CartProductDetails { get; set; }
    }
}
