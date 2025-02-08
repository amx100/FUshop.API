using Domain.Entities;

namespace Contract.DataTransferObject;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string HeroImage { get; set; }
    public int CategoryId { get; set; }

}

public class ProductCreateDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string HeroImage { get; set; }
    public int CategoryId { get; set; }
}

public class ProductUpdateDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string HeroImage { get; set; }
    public int CategoryId { get; set; }
}

