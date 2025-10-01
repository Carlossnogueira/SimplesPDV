using SimplesPDV.Communication.Request;
using SimplesPDV.Communication.Response;
using SimplesPDV.Domain.Repository;
using SimplesPDV.Domain.Repository.Product;
using SimplesPDV.Exception.Validation;

namespace SimplesPDV.Application.Services.Product.Create;

public class CreateProductService : ICreateProductService
{
    private readonly IProductWriteOnlyRepository  _repository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateProductService(IProductWriteOnlyRepository productRepository, IUnityOfWork unityOfWork)
    {
        _repository = productRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ResponseProductCreatedJson> Execute(RequestProductJson product)
    {
        Validate(product);

        var fullProduct = new Domain.Product()
        {
            Name = product.Name,
            Price = product.Price,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Quantity = product.Quantity,
            ModifiedAt = DateTime.UtcNow,
        };

        await _repository.AddAsync(fullProduct);
        await _unityOfWork.Commit();

        var response = new ResponseProductCreatedJson()
        {
            Name = product.Name
        };
        
        return response;
    }

    private void Validate(RequestProductJson product)
    {
        var validator = new CreateProductValidator();
        var result = validator.Validate(product);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}