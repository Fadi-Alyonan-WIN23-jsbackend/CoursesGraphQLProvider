using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Factories;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Services;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest request);
    Task<Course> GetCourseByIdAsync(string id);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);
    Task<bool> DeleteCourseAsync(string id);
}

public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = CourseFactory.Create(request);
        context.Courses.Add(courseEntity);
        await context.SaveChangesAsync();

        return CourseFactory.Create(courseEntity);
    }

    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

        if (courseEntity == null)
        {
            return false;
        }
        context.Courses.Remove(courseEntity);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

        return courseEntity == null ? null! : CourseFactory.Create(courseEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntities = await context.Courses.ToListAsync();

        return courseEntities.Select(CourseFactory.Create);
    }

    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var existingCourse = await context.Courses
            .Include(c => c.Prices)
            .Include(c => c.CourseContent)
            .ThenInclude(cc => cc.CourseDetails)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (existingCourse == null)
        {
            return null!;
        }

        var updatedCourseEntity = CourseFactory.Create(request);

        context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);

        if (updatedCourseEntity.Prices != null)
        {
            if (existingCourse.Prices == null)
            {
                existingCourse.Prices = new CoursePriceEntity();
            }
            context.Entry(existingCourse.Prices).CurrentValues.SetValues(updatedCourseEntity.Prices);
        }
        else
        {
            existingCourse.Prices = null;
        }

        if (updatedCourseEntity.CourseContent != null)
        {
            if (existingCourse.CourseContent == null)
            {
                existingCourse.CourseContent = new CourseContentEntity();
            }
            context.Entry(existingCourse.CourseContent).CurrentValues.SetValues(updatedCourseEntity.CourseContent);

            existingCourse.CourseContent.CourseDetails.Clear();
            foreach (var detail in updatedCourseEntity.CourseContent.CourseDetails)
            {
                existingCourse.CourseContent.CourseDetails.Add(new CourseDetailsItemEntity
                {
                    Id = detail.Id,
                    Title = detail.Title,
                    Description = detail.Description
                });
            }
        }
        else
        {
            existingCourse.CourseContent = null;
        }

        await context.SaveChangesAsync();
        return CourseFactory.Create(existingCourse);
    }
}
