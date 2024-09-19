using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        protected CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                Customer? customer = await _dbContext.Customers.FindAsync(id);
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving customer with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error retrieving customers: " + ex.Message, ex);
            }
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _dbContext.Customers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Customer entity)
        {
            var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = entity.Name;
                existingCustomer.Team = entity.Team;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;

        }

    }
    }
