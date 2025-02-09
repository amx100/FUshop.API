namespace Contract.DataTransferObject;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }

}

public class CategoryCreateDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }

}

public class CategoryUpdateDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
}

