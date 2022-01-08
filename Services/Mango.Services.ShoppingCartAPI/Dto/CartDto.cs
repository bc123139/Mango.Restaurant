﻿
using System.Collections.Generic;


namespace Mango.Services.ShoppingCartAPI.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
