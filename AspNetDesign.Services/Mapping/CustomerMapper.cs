using AspNetDesign.Model.Customers;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerDetailView(this Customer customer)
        {
            return Mapper.Map<Customer, CustomerView>(customer);
        }
    }
}
