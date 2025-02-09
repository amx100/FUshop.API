namespace Contract.DataTransferObject;

public class OrderDto
{
    public int OrderId { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string Slug { get; set; }
    public decimal TotalPrice { get; set; }

}

public class OrderCreateDto
{
    public string Status { get; set; }
    public string Description { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string Slug { get; set; }
    public decimal TotalPrice { get; set; }

}

public class OrderUpdateDto
{
    public string Status { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
}
