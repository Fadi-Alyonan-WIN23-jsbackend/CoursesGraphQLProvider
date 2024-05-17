namespace CourseProvider.Infrastructure.Data.Entities;

public class CourseContentEntity
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<CourseDetailsItemEntity>? CourseDetails {  get; set; }
}
