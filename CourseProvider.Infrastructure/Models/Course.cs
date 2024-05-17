namespace CourseProvider.Infrastructure.Models;

public class Course
{
    public string Id { get; set; } = null!;
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public string? Author { get; set; }
    public virtual CoursePrice? Prices { get; set; }
    public virtual CourseContent? CourseContent { get; set; }
}

public class CoursePrice
{
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}

public class CourseContent
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<CourseDetailsItem>? CourseDetails { get; set; }
}

public class CourseDetailsItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}