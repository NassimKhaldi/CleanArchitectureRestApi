using MediatR;
using restapi.Core.Entities;
using restapi.Infrastructure.Data;

namespace restapi.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(request.Id);
        }
    }
}
