using Bogus;
using SimplesPDV.Communication.Request;

namespace CommonTestUtilities;

public class RequestCreateProductJsonBuilder
{
    public static Faker<RequestProductJson>  Build()
    {
        return new Faker<RequestProductJson>()
            .RuleFor(r => r.Name, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Quantity, faker => faker.Random.Int(min: 1, max: 999))
            .RuleFor(r => r.Price, faker => faker.Random.Decimal(min: 00,01));
    }
}