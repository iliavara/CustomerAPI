using Dapper;
using Domain;
using Domain.Models.Customer;
using Microsoft.Extensions.Options;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ConnectionString _connectionStrings;

        public CustomerRepository(IOptions<ConnectionString> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<bool> Delete(int CustomerID)
        {
            int response;
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("ID", CustomerID);
                response = await connection.ExecuteAsync("dbo.CustomerDelete",
                    queryParameters,
                    null,
                    200,
                    CommandType.StoredProcedure);
            }
            return Convert.ToBoolean(response);
        }

        public async Task<CustomerResponseModel> Get(int PatientID)
        {
            var response = new CustomerResponseModel();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ID", PatientID);
                response = await connection.QuerySingleOrDefaultAsync<CustomerResponseModel>("dbo.CustomerGet",
                    queryParameters,
                    null,
                    200,
                    CommandType.StoredProcedure);
            }
            return response;
        }

        public async Task<IEnumerable<CustomerResponseModel>> ListGet()
        {
            IEnumerable<CustomerResponseModel> response = new List<CustomerResponseModel>();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Name", "");
                response = await connection.QueryAsync<CustomerResponseModel>("dbo.CustomerGetList",
                    queryParameters,
                    commandType: CommandType.StoredProcedure);
            }
            return response.ToList();
        }

        public async Task<int> Post(CustomerRequestModel model)
        {
            int response;
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ID", model.ID);
                queryParameters.Add("@Name", model.Name);
                queryParameters.Add("@Phone", model.Phone);
                response = await connection.ExecuteScalarAsync<int>("dbo.CustomerPost",
                    queryParameters,
                    null,
                    200,
                    CommandType.StoredProcedure
                    );
            }
            return response;
        }
    }
}
