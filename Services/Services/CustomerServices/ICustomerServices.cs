using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CustomerServices
{
    public interface ICustomerServices
    {
        public Task<GeneralResponseModel<IEnumerable<CustomerResponseModel>>> ListGet();
        public Task<GeneralResponseModel<CustomerResponseModel>> Get(int CustomerID);
        public Task<GeneralResponseModel<int>> Post(CustomerRequestModel model);
        public Task<GeneralResponseModel<Boolean>> Delete(int PatientID);
    }
}
