

namespace Domain.Customers;

public interface ICustomerRepository{

    Task<Customer?> GetByIdAsync(CustomerId id);

    Task Add (Customer customer);

     Task<List<Customer>> GetAllAsync();
}