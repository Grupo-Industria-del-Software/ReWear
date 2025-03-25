using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces.RentalApplications;
using Domain.AggregateRoots.Products;

namespace Infrastructure.Persistence.Repositories
{
    public class RentalApplicationRepository : IRentalApplicationRepository
    {
        private readonly AlqDbContext _context;

        public RentalApplicationRepository(AlqDbContext context)
        {
            _context = context;
        }

        public async Task<RentalApplication> GetByIdAsync(int id)
        {
            return await _context.RentalApplications
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Category)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Condition)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Size)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Brand)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.ProductStatus)
                .Include(ra => ra.RequesterUser)
                .Include(ra => ra.ProductOwnerUser)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(ra => ra.Id == id);
        }

        public async Task<IEnumerable<RentalApplication>> GetAllAsync()
        {
            return await _context.RentalApplications.ToListAsync();
        }

        public async Task<IEnumerable<RentalApplication>> GetByUserIdAsync(int userId)
        {
            return await _context.RentalApplications
                .Include(ra => ra.RequesterUser)
                .Include(ra => ra.ProductOwnerUser)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.User) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Category) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Condition) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Size) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Brand) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.ProductStatus) 
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.ProductImages) 
                .Include(ra => ra.Status) 
                    .Where(ra => ra.RequesterUserId == userId || ra.ProductOwnerUserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(RentalApplication rentalApplication)
        {
            await _context.RentalApplications.AddAsync(rentalApplication);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentalApplication rentalApplication)
        {
            _context.Entry(rentalApplication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RentalApplication>> GetByProductIdAsync(int productId)
        {
            return await _context.RentalApplications
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.User)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Category)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Condition)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Size)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.Brand)
                .Include(ra => ra.Product)
                    .ThenInclude(p => p.ProductStatus)
                .Include(ra => ra.RequesterUser)
                .Include(ra => ra.ProductOwnerUser)
                .Include(ra => ra.Product.ProductImages)
                .Where(ra => ra.ProductId == productId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _context.RentalApplications.FindAsync(id);
            if (application != null)
            {
                _context.RentalApplications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }
}
