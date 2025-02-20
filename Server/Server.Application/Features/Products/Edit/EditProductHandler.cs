using AutoMapper;
using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Edit;

public sealed class EditProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<EditProductRequest, EditProductResponse>
{
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<EditProductResponse> Handle(
        EditProductRequest request, CancellationToken cancellationToken)
    {
        bool exists = await productRepository.Exists(Guid.Parse(request.Id!), cancellationToken);
        if(!exists) {
            throw new AppException("Product not found", 404);
        }

        var product = mapper.Map<Product>(request);
        product.Id = Guid.Parse(request.Id!);
        productRepository.Update(product);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<EditProductResponse>(product);
    }
}