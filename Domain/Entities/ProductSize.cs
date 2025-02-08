namespace Domain.Entities;

public class ProductSize
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }


    public Product Product { get; set; }
    public Size Size { get; set; }
}
