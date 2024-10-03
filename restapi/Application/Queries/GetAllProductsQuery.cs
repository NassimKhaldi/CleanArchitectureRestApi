using MediatR;
using restapi.Core.Entities;
using restapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace restapi.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>> { }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
