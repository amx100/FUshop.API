namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string Slug { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public virtual Account Account { get; set; } = null!;
}
