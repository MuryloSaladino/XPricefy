using MediatR;

namespace Server.Application.Features.Products.Edit;

public sealed class EditProductRequest(
    string? id,
    string name,
    decimal price,
    int clientsNumber,
    int yearsToPay
) : IRequest<EditProductResponse>
{
    public string? Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int ClientsNumber { get; set; } = clientsNumber;
    public int YearsToPay { get; set; } = yearsToPay;
}