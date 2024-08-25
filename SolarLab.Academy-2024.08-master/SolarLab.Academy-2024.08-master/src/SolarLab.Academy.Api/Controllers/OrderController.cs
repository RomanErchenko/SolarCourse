using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Order.Service;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Contracts.Orders;

namespace SolarLab.Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {

            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {

            var result = await _orderService.Getall(cancellationToken);


            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] OrderDto order, CancellationToken cancellationToken)
        {
            var us = await _orderService.AddOrder(order, cancellationToken);
            return Ok(us);

        }
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Guid id, [FromBody] OrderDto order, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrder(id, order, cancellationToken);
            return Ok();

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await _orderService.DeleteOrder(id, cancellationToken);
            return Ok();
        }

    }
}
