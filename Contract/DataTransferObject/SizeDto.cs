namespace Contract.DataTransferObject;

public class SizeDto
{
    public int SizeId { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}


public class SizeCreateDto
{
    public string Name { get; set; }

}

public class SizeUpdateDto
{
    public string Name { get; set; }

}