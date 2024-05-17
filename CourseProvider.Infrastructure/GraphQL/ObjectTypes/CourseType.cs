using CourseProvider.Infrastructure.Data.Entities;

namespace CourseProvider.Infrastructure.GraphQL.ObjectTypes;

public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.IsBestSeller).Type<BooleanType>();
        descriptor.Field(c => c.IsDigital).Type<BooleanType>();
        descriptor.Field(c => c.Categories).Type<ListType<StringType>>();
        descriptor.Field(c => c.Title).Type<StringType>();
        descriptor.Field(c => c.Ingress).Type<StringType>();
        descriptor.Field(c => c.StarRating).Type<DecimalType>();
        descriptor.Field(c => c.Reviews).Type<StringType>();
        descriptor.Field(c => c.LikesInPercent).Type<StringType>();
        descriptor.Field(c => c.Likes).Type<StringType>();
        descriptor.Field(c => c.Hours).Type<StringType>();
        descriptor.Field(c => c.Author).Type<StringType>();
        descriptor.Field(c => c.Prices).Type<PriceType>();
        descriptor.Field(c => c.CourseContent).Type<CourseContentType>();
    }
}

public class PriceType : ObjectType<CoursePriceEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CoursePriceEntity> descriptor)
    {
        descriptor.Field(c => c.Price).Type<DecimalType>();
        descriptor.Field(c => c.Discount).Type<DecimalType>();
    }
}

public class CourseContentType : ObjectType<CourseContentEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseContentEntity> descriptor)
    {
        descriptor.Field(c => c.Description).Type<StringType>();
        descriptor.Field(c => c.Includes).Type<ListType<StringType>>();
        descriptor.Field(c => c.CourseDetails).Type<ListType<CourseDetailsItemType>>();
    }
}

public class CourseDetailsItemType : ObjectType<CourseDetailsItemEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseDetailsItemEntity> descriptor)
    {
        descriptor.Field(cd => cd.Id).Type<IntType>();
        descriptor.Field(cd => cd.Title).Type<StringType>();
        descriptor.Field(cd => cd.Description).Type<StringType>();
    }
}