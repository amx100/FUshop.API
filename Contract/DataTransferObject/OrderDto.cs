namespace Contract.DataTransferObject;

public class OrderDto
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string Slug { get; set; }
    public decimal TotalPrice { get; set; }

}

public class CreateOrderDto
{
    public string Status { get; set; }
    public string Description { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string Slug { get; set; }
    public decimal TotalPrice { get; set; }

}

public class UpdateOrderDto
{
    public string Status { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
}
