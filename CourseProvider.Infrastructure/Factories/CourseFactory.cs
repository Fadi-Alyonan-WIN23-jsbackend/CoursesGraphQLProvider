using Azure.Core;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;

namespace CourseProvider.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInPercent = request.LikesInPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Author = request.Author,
            Prices = request.Prices == null ? null : new CoursePriceEntity
            {
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            CourseContent = request.CourseContent == null ? null : new CourseContentEntity
            {
                Description = request.CourseContent.Description,
                Includes = request.CourseContent.Includes,
                CourseDetails = request.CourseContent.CourseDetails?.Select(cd => new CourseDetailsItemEntity
                {
                    Id = cd.Id,
                    Title = cd.Title,
                    Description = cd.Description,
                }).ToList()
            }
        };
    }

    public static CourseEntity Create(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInPercent = request.LikesInPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Author = request.Author,
            Prices = request.Prices == null ? null : new CoursePriceEntity
            {
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            CourseContent = request.CourseContent == null ? null : new CourseContentEntity
            {
                Description = request.CourseContent.Description,
                Includes = request.CourseContent.Includes,
                CourseDetails = request.CourseContent.CourseDetails?.Select(cd => new CourseDetailsItemEntity
                {
                    Id = cd.Id,
                    Title = cd.Title,
                    Description = cd.Description,
                }).ToList()
            }
        };
    }

    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            ImageUri = entity.ImageUri,
            ImageHeaderUri = entity.ImageHeaderUri,
            IsBestSeller = entity.IsBestSeller,
            IsDigital = entity.IsDigital,
            Categories = entity.Categories,
            Title = entity.Title,
            Ingress = entity.Ingress,
            StarRating = entity.StarRating,
            Reviews = entity.Reviews,
            LikesInPercent = entity.LikesInPercent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Author = entity.Author,
            Prices = entity.Prices == null ? null : new CoursePrice
            {
                Price = entity.Prices.Price,
                Discount = entity.Prices.Discount
            },
            CourseContent = entity.CourseContent == null ? null : new CourseContent
            {
                Description = entity.CourseContent.Description,
                Includes = entity.CourseContent.Includes,
                CourseDetails = entity.CourseContent.CourseDetails?.Select(cd => new CourseDetailsItem
                {
                    Id = cd.Id,
                    Title = cd.Title,
                    Description = cd.Description,
                }).ToList()
            }
        };
    }
}
