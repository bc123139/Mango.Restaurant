
using System.Collections.Generic;


namespace Mango.Services.ShoppingCartAPI.Database.Entities
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
