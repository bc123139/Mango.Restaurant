using Mango.Services.CouponAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.CouponAPI.Database
{
    public static class DatabaseContextSeed
    {
        public static async Task SeedDataAsync(DatabaseContext context)
        {
            await AddPreConfiguredCoupons(context);
        }
        private static async Task AddPreConfiguredCoupons(DatabaseContext context)
        {
            var coupons = context.Coupons.ToList();
            var newCoupons = new List<Coupon>
            {
                new Coupon
                {
                CouponCode = "10OFF",
                DiscountAmount = 10
                },
                new Coupon
                {
                CouponCode = "20OFF",
                DiscountAmount = 20
                }
               

            };
            var result = newCoupons.Where(gc => coupons.All(newGc => !string.Equals(newGc.CouponCode, gc.CouponCode, StringComparison.CurrentCultureIgnoreCase))).ToList();
            await context.Coupons.AddRangeAsync(result);
            await context.SaveChangesAsync();
        }
    }
}
