using AutoMapper;
using MediatR;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Create;

public sealed class CreateProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateProductResponse> Handle(
        CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        productRepository.Create(product);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateProductResponse>(product);
    }
}