namespace Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{

    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Customer customer)=> await _context.Customers.AddAsync(customer);

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(CustomerId id)=> await _context.Customers.SingleOrDefaultAsync(c=>c.CustomerId==id);

    
}

