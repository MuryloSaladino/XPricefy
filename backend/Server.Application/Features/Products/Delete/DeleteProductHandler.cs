using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Application.Repository.Users;
using Server.Domain.Common;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Features.Products.Delete;

public sealed class DeleteProductHandler(
    IProductHistoryRepository productHistoryRepository,
    IProductRepository productRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    UserSession session
) : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IProductHistoryRepository productHistoryRepository = productHistoryRepository;
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;

    public async Task<DeleteProductResponse> Handle(
        DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(Guid.Parse(request.Id), cancellationToken) 
            ?? throw new AppException("Product not found", 404);

        productRepository.Delete(product);

        var userId = session.Id ?? throw new AppException("Unauthorized", 401);
        var user = await userRepository.Get(userId, cancellationToken)
            ?? throw new AppException("User not found", 404);

        var history = new ProductHistory()
        {
            Action = HistoryAction.Deleted,
            Product = product,
            ProductId = product.Id,
            User = user,
            UserId = userId
        };
        productHistoryRepository.Create(history);

        await unitOfWork.Save(cancellationToken);

        return new DeleteProductResponse();
    }
}