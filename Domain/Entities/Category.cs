﻿namespace Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
    public List<Product> Products { get; set; }
}
