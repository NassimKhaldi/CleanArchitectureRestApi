using MediatR;
using restapi.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace restapi.Application.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

