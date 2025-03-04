﻿namespace Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string HeroImage { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}