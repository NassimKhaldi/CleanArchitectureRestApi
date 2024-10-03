using MediatR;
using restapi.Core.Entities;
using restapi.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace restapi.Application.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
