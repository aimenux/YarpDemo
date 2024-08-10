using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using CustomersMicroservice.Models;

namespace CustomersMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly string[] Customers = new[]
    {
        "Walter White", "John Travolta", "Sofia Antipolis"
    };

    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ILogger<CustomersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        return Enumerable.Range(1, Customers.Length)
            .Select(index => new Customer
            {
                CustomerId = index,
                FullName = Customers[index-1],
                Age = Random.Shared.Next(20, 80)
            }).ToArray();
    }
}