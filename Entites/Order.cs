using Core.Abstract;

namespace Entites
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public virtual List<OrderItem>? OrderItems { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal TaxPrice { get; set; }

    }
}
