namespace CustomerApi.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);

        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> AddAsync(Customer entity);

        Task UpdateAsync(Customer entity);

        Task<bool> DeleteAsync(int id);

    }
}
