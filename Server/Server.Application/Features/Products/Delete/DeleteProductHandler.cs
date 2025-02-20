using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository;
using Server.Application.Repository.Products;

namespace Server.Application.Features.Products.Delete;

public sealed class DeleteProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteProductResponse> Handle(
        DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(Guid.Parse(request.Id), cancellationToken) 
            ?? throw new AppException("User not found", 404);

        productRepository.Delete(product);
        await unitOfWork.Save(cancellationToken);

        return new DeleteProductResponse();
    }
}