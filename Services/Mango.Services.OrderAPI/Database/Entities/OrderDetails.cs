using System.ComponentModel.DataAnnotations.Schema;


namespace Mango.Services.OrderAPI.Database.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public virtual OrderHeader OrderHeader { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
