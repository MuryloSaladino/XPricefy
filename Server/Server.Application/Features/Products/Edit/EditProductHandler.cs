using AutoMapper;
using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Application.Repository.Users;
using Server.Domain.Common;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Features.Products.Edit;

public sealed class EditProductHandler(
    IProductHistoryRepository productHistoryRepository,
    IProductRepository productRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<EditProductRequest, EditProductResponse>
{
    private readonly IProductHistoryRepository productHistoryRepository = productHistoryRepository;
    private readonly IProductRepository productRepository = productRepository;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
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

        var user = await userRepository.Get(session.Id, cancellationToken)
            ?? throw new AppException("User not found", 404);

        var history = new ProductHistory()
        {
            Action = HistoryAction.UPDATE,
            Product = product,
            User = user
        };
        productHistoryRepository.Create(history);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<EditProductResponse>(product);
    }
}