using AutoMapper;
using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Application.Repository.Users;
using Server.Domain.Common;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Features.Products.Create;

public sealed class CreateProductHandler(
    IProductHistoryRepository productHistoryRepository,
    IProductRepository productRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductHistoryRepository productHistoryRepository = productHistoryRepository;
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
    private readonly IMapper mapper = mapper;

    public async Task<CreateProductResponse> Handle(
        CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        productRepository.Create(product);
        
        var userId = session.Id ?? throw new AppException("Unauthorized", 401);
        var user = await userRepository.Get(userId, cancellationToken)
            ?? throw new AppException("User not found", 404);

        var history = new ProductHistory()
        {
            Action = HistoryAction.Created,
            Product = product,
            ProductId = product.Id,
            User = user,
            UserId = userId
        };
        productHistoryRepository.Create(history);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateProductResponse>(product);
    }
}