using MediatR;

namespace Server.Application.Features.Products.FindAll;

public sealed record FindAllProductsRequest() : IRequest<List<FindAllProductsResponse>>;