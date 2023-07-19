using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using OrdersMicroservice.Models;

namespace OrdersMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        return Enumerable.Range(1, 10)
            .Select(index => new Order
            {
                OrderId = index,
                CustomerId = Random.Shared.Next(10),
                OrderDate = DateTime.Now.AddDays(-index),
                OrderLines = new List<OrderLine>
                {
                    new OrderLine
                    {
                        OrderLineId = Random.Shared.Next(10),
                        ProductId = Random.Shared.Next(30),
                        Quantity = Random.Shared.Next(5)
                    }
                }
            }).ToArray();
    }
}