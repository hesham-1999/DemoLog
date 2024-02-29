using AutoMapper;
using DemoLog.Controllers.Request;
using DemoLog.Dmoain;
using DemoLog.Mediator.Command;
using DemoLog.Mediator.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace DemoLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;
        public OrderController(ISender _sender)
        {
           this._sender = _sender;
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            var orderResponse = await _sender.Send(new CreateOrderCommand(orderRequest));
            return CreatedAtRoute(nameof(GetOrderById), new {Id = orderResponse.Id} ,orderResponse);
        }

        [HttpGet]
        [OutputCache]
        public async Task<IActionResult> getAll()
        {
          var respose = await _sender.Send(new GetOrderQuery());    
          return Ok(respose);
        }


        [HttpGet("{Id:int}" ,Name ="GetOrderById")]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            var respose = await _sender.Send(new GetOrderByIdQuery(Id));
            return Ok(respose);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int orderid)
        {
            await _sender.Send(new DeleteOrderCommand(orderid));
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateRequest orderUpdateRequest)
        {
            var flag = await _sender.Send(new UpdateOrderCommand(orderUpdateRequest));
            if(flag)
                return Ok("updated");
            return BadRequest("Invalid Id");
        }
    }
}
