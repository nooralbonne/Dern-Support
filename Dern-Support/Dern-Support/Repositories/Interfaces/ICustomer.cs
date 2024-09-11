using Dern_Support.Model;
using Dern_Support.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Interfaces
{
    public interface ICustomer
    {
        // Create a customer based on CustomerDto
        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);

        // Retrieve all customers as a list of CustomerDto
        Task<List<CustomerDto>> GetAllCustomers();

        // Retrieve a specific customer by ID and return as CustomerDto
        Task<CustomerDto> GetCustomerById(int customerId);

        // Update a customer based on the provided CustomerDto and ID
        Task<CustomerDto> UpdateCustomer(int id, CustomerDto customerDto);

        // Delete a customer by ID
        Task DeleteCustomer(int id);
    }
}
