﻿
namespace Mango.Services.CouponAPI.Database.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
