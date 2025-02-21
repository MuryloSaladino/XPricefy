using MediatR;

namespace Server.Application.Features.Products.Delete;

public sealed record DeleteProductRequest(
    string Id
) : IRequest<DeleteProductResponse>; 