using MediatR;
using restapi.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace restapi.Application.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
