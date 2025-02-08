﻿namespace Contract.DataTransferObject;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
}

public class CreateCategoryDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public string Slug { get; set; }

}

public class UpdateCategoryDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
}

