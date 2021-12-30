using SampleShoppingCartAPI.Business;
using SampleShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShoppingCartAPI.Services
{
    public class ShoppingCartService : IShoppingCartBusiness
    {
        private readonly ShoppingCartSampleContext _context;
        public List<ProductModels> GetProducts()
        {
            try
            {
                List<ProductModels> productInformation;
                using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
                {
                    productInformation = dbcontext.ProductInformations.Select(x => new ProductModels
                    {
                        ProductId = x.ProductId,
                        ProductTitle = x.ProductTitle,
                        Description = x.Description,
                        Price = x.Price.ToString(),
                        ModelNumber = x.ModelNumber
                    }).ToList();
                }

                return productInformation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductModels GetProductByID(int id)
        {
            try
            {

                using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
                {
                    var productInformation = dbcontext.ProductInformations.Where(x => x.ProductId == id).Select(x => new ProductModels
                    {
                        ProductId = x.ProductId,
                        ProductTitle = x.ProductTitle,
                        Description = x.Description,
                        Price = x.Price.ToString(),
                        ModelNumber = x.ModelNumber
                    }).FirstOrDefault();


                    return productInformation;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddToCart(int id)
        {
            using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
            {
                CartProductDetail cartinfo;

                cartinfo = dbcontext.CartProductDetails.Where(x => x.UserId == 1 && x.ProductId == id).FirstOrDefault();
                if (cartinfo == null)
                {
                    cartinfo = new CartProductDetail();
                    cartinfo.UserId = 1;
                    cartinfo.ProductId = id;
                    cartinfo.Quantity = 1;
                    dbcontext.CartProductDetails.Add(cartinfo);
                }
                else
                {
                    cartinfo.Quantity = cartinfo.Quantity + 1;
                }
                dbcontext.SaveChanges();
            }





        }
        public void DeleteCart(int productId)
        {
            using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
            {
                CartProductDetail cartinfo;
                cartinfo = dbcontext.CartProductDetails.Where(x => x.UserId == 1 && x.ProductId == productId).FirstOrDefault();
                if (cartinfo.Quantity == 1)
                {
                    dbcontext.CartProductDetails.Remove(cartinfo);
                }
                else
                {
                    cartinfo.Quantity = cartinfo.Quantity - 1;
                }
                dbcontext.SaveChanges();
            }

        }
        public List<CartInformationModel> Checkout()
        {
            List<CartInformationModel> cartInformation;
            using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
            {
                cartInformation = dbcontext.CartProductDetails.Select(x => new CartInformationModel
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = dbcontext.ProductInformations.Where(p => p.ProductId == x.ProductId).FirstOrDefault().Price,
                    productTitle = dbcontext.ProductInformations.Where(p => p.ProductId == x.ProductId).FirstOrDefault().ProductTitle
                }).ToList();
            }
            return cartInformation;
        }
        public int getCartCount()
        {
            try
            {
                int cartCount = 0;
                using (ShoppingCartSampleContext dbcontext = new ShoppingCartSampleContext())
                {
                    cartCount = dbcontext.CartProductDetails.Where(x => x.UserId == 1).Select(x => x.Quantity).Sum();
                }
                return cartCount;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
