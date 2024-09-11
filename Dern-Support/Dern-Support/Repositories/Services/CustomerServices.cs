using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Services
{

    public class CustomerServices : ICustomer
    {
        private readonly DernSupportDbContext _context;

        public CustomerServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            // Manually map CustomerDto to Customer entity
            var customer = new Customer
            {
                UserId = customerDto.UserId,
                Name = customerDto.Name,
                CustomerType = customerDto.CustomerType,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email,
                CompanyName = customerDto.CompanyName,
                CreatedDate = customerDto.CreatedDate
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Return the created customer as a DTO
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                UserId = customer.UserId,
                Name = customer.Name,
                CustomerType = customer.CustomerType,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                CompanyName = customer.CompanyName,
                CreatedDate = customer.CreatedDate
            };
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            // Manually map List<Customer> to List<CustomerDto>
            var customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(new CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    UserId = customer.UserId,
                    Name = customer.Name,
                    CustomerType = customer.CustomerType,
                    Address = customer.Address,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    CompanyName = customer.CompanyName,
                    CreatedDate = customer.CreatedDate
                });
            }

            return customerDtos;
        }

        public async Task<CustomerDto> GetCustomerById(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) return null;

            // Manually map Customer to CustomerDto
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                UserId = customer.UserId,
                Name = customer.Name,
                CustomerType = customer.CustomerType,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                CompanyName = customer.CompanyName,
                CreatedDate = customer.CreatedDate
            };
        }

        public async Task<CustomerDto> UpdateCustomer(int id, CustomerDto customerDto)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null) return null;

            // Update the properties manually
            existingCustomer.UserId = customerDto.UserId;
            existingCustomer.Name = customerDto.Name;
            existingCustomer.CustomerType = customerDto.CustomerType;
            existingCustomer.Address = customerDto.Address;
            existingCustomer.PhoneNumber = customerDto.PhoneNumber;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.CompanyName = customerDto.CompanyName;
            existingCustomer.CreatedDate = customerDto.CreatedDate;

            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();

            // Return the updated customer as a DTO
            return new CustomerDto
            {
                CustomerId = existingCustomer.CustomerId,
                UserId = existingCustomer.UserId,
                Name = existingCustomer.Name,
                CustomerType = existingCustomer.CustomerType,
                Address = existingCustomer.Address,
                PhoneNumber = existingCustomer.PhoneNumber,
                Email = existingCustomer.Email,
                CompanyName = existingCustomer.CompanyName,
                CreatedDate = existingCustomer.CreatedDate
            };
 
}
    }
}

