using CatalogService.Application.Commands;
using CatalogService.Database;
using CatalogService.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly DatabaseContext _db;
        public DeleteProductCommandHandler(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _db.Products.FindAsync(request.Id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
