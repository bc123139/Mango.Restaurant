﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCartAPI.Dto
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
