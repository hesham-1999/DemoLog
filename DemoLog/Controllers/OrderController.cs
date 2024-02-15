using AutoMapper;
using DemoLog.Controllers.Request;
using DemoLog.Controllers.Response;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg;
using DemoLog.Dmoain.OrderAgg.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IMapper mapper , IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this._orderRepository = orderRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            var orederInput = mapper.Map<OrderInput>(orderRequest);
            var order = new Order(orederInput);
            _orderRepository.Create(order);
            await _orderRepository.SaveSchangesAsync();
            return Ok("created Succefuly");
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
           var resultModel = await _orderRepository.getAllAsyn();
            var respose = mapper.Map<List<OrderResponse>>(resultModel);
          return Ok(respose);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int orderid)
        {
           var deletedorder= await _orderRepository.Getbyid(orderid);
            deletedorder.Delete();
            await _orderRepository.SaveSchangesAsync();
            return Ok("Order Deleted SuCCIFFULY");
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateRequest orderUpdateRequest)
        {
            var updateorder =await _orderRepository.Getbyid(orderUpdateRequest.Id);
            if (updateorder != null)
            {
              var orderinput=  mapper.Map<OrderUpdateInput>(orderUpdateRequest);
                updateorder.Update(orderinput);
                await _orderRepository.SaveSchangesAsync();
                return Ok("updated");
            }
            return BadRequest("Invalid Id");
        }

    }
}
