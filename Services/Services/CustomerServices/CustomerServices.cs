using Domain.Models.Customer;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CustomerServices
{
    public class CustomerServices : ICustomerServices

    {
        #region ctor
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        public async Task<GeneralResponseModel<CustomerResponseModel>> Get(int CustomerID)
        {
            var response = new GeneralResponseModel<CustomerResponseModel>();
            try
            {
                response.Data = await _customerRepository.Get(CustomerID);
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponseModel<IEnumerable<CustomerResponseModel>>> ListGet()
        {
            var response = new GeneralResponseModel<IEnumerable<CustomerResponseModel>>();
            try
            {
                response.Data = await _customerRepository.ListGet();
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponseModel<int>> Post(CustomerRequestModel model)
        {
            var response = new GeneralResponseModel<int>();
            try
            {
                response.Data = await _customerRepository.Post(model);
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error " + ex.Message;
            }
            return response;
        }
        public async Task<GeneralResponseModel<Boolean>> Delete(int CustomerID)
        {
            var response = new GeneralResponseModel<Boolean>();
            try
            {
                response.Data = await _customerRepository.Delete(CustomerID);
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
