namespace Contract.DataTransferObject;


public class OrderItemDto
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int SizeId { get; set; }
}

public class OrderItemCreateDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int SizeId { get; set; }
}

public class OrderItemUpdateDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int SizeId { get; set; }
}