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
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Price_Less_Than_Zero(decimal price)
    {
        var validator = new CreateProductValidator();
        var request = (RequestProductJson)RequestCreateProductJsonBuilder.Build();
        request.Price = price;
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Price must be greater than 0"));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Quantity_Less_Than_Zero(int quantity)
    {
        var validator = new CreateProductValidator();
        var request = (RequestProductJson)RequestCreateProductJsonBuilder.Build();
        request.Quantity = quantity;
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Quantity is required and greater than 1"));
    }

    [Fact]
    public void Error_Product_More_Than_Nine_Thousand_Nine_Hundred_ninety_nine()
    {
        var validator = new CreateProductValidator();
        var request = (RequestProductJson)RequestCreateProductJsonBuilder.Build();
        request.Quantity = 99999;
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Quantity must be less than or equal to 9999"));
    }
}