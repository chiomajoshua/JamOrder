﻿using JamOrder.Core.Services.Customer.Interface;
using JamOrder.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace JamOrder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public OnboardingController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("OnboardCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> OnboardCustomer(CreateCustomerRequest createCustomerRequest)
        {
            var customerResult = await _customerService.IsCustomerExists(createCustomerRequest.EmailAddress);
            if (customerResult) return Conflict();

            if(await _customerService.CreateCustomer(createCustomerRequest)) return NoContent();

            return Problem();
        }
    }
}