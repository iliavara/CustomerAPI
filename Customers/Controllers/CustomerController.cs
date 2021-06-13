using Attributes;
using Domain.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Controllers
{
    [Route("Customer")]
   // [APIAuthentication]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("ListGet")]
        public async Task<IActionResult> ListGet()
        {
            try
            {
                var generalResponseModel = await _customerServices.ListGet();
                if (generalResponseModel.Status)
                    return Ok(generalResponseModel);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int PatientID)
        {
            try
            {
                var generalResponseModel = await _customerServices.Get(PatientID);
                if (generalResponseModel.Status)
                    return Ok(generalResponseModel);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel model)
        {
            try
            {
                var generalResponseModel = await _customerServices.Post(model);
                if (generalResponseModel.Status)
                    return Ok(generalResponseModel);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int PatientID)
        {
            try
            {
                var generalResponseModel = await _customerServices.Delete(PatientID);
                if (generalResponseModel.Status)
                    return Ok(generalResponseModel);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
