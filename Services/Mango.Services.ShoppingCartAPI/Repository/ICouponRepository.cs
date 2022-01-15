
using Mango.Services.ShoppingCartAPI.Dto;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
