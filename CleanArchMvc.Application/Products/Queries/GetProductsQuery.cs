using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    internal class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
