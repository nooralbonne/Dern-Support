﻿namespace Dern_Support.Model.DTO
{
    //Purpose: Represents customer details.
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
