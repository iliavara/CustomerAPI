using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<CustomerResponseModel>> ListGet();
        public Task<CustomerResponseModel> Get(int PatientID);
        public Task<int> Post(CustomerRequestModel model);
        public Task<bool> Delete(int CustomerID);
    }
}
