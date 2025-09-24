using CommonTestUtilities;
using SimplesPDV.Application.Services.Product.Create;
using FluentAssertions;
using SimplesPDV.Communication.Request;


namespace ValidatorsTests.Product.Create;

public class CreateProductValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new CreateProductValidator();
        var request = RequestCreateProductJsonBuilder.Build();
        var result = validator.Validate(request);
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void Error_Name_Empty(string name)
    {
        var validator = new CreateProductValidator();
        var request = (RequestProductJson)RequestCreateProductJsonBuilder.Build();
        request.Name = name;

        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Name is required"));
    }
}