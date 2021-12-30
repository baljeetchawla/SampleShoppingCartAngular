using SampleShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShoppingCartAPI.Business
{
    public interface IShoppingCartBusiness
    {
        List<ProductModels> GetProducts();
        ProductModels GetProductByID(int id);
        void AddToCart(int id);
        void DeleteCart(int productId);
        List<CartInformationModel> Checkout();
        int getCartCount();
    }
}
