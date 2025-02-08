namespace Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OrderId { get; set; }
   
    public int ProductId { get; set; }
    
    public int Quantity { get; set; }
    public int SizeId { get; set; }



    public Size Size { get; set; }
    public Product Product { get; set; }
    public Order Order { get; set; }
}
