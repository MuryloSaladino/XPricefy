using AutoMapper;
using MediatR;
using Server.Application.Repository.Products;

namespace Server.Application.Features.Products.Find;

public sealed class FindProductHandler(
    IProductRepository productRepository,
    IMapper mapper
) : IRequestHandler<FindProductRequest, FindProductResponse>
{
    private readonly IProductRepository productRepository = productRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindProductResponse> Handle(
        FindProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(Guid.Parse(request.Id), cancellationToken);
        return mapper.Map<FindProductResponse>(product);
    }
}