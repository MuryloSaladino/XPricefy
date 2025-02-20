using MediatR;

namespace Server.Application.Features.Products.Find;

public sealed record FindProductRequest(
    string Id
) : IRequest<FindProductResponse>;