using AutoMapper;
using DemoLog.Controllers.Request;
using DemoLog.Controllers.Response;
using DemoLog.Dmoain.OrderAgg;
using DemoLog.Dmoain.OrderAgg.Input;

namespace DemoLog.AutoMapper
{
    public class Myprofiler : Profile
    {
        public Myprofiler()
        {
            CreateMap<OrderInput,OrderRequest>().ReverseMap();
            CreateMap<OrderItemInput,OrderItemRequest>().ReverseMap();

            CreateMap<OrderResponse, Order>().ReverseMap();
            CreateMap<orderItemRespose, orderItem>().ReverseMap();


            CreateMap<OrderUpdateInput, OrderUpdateRequest>().ReverseMap();
            CreateMap<OrderItemUpdateInput, OrderItemUdateRequest>().ReverseMap();
        }
    }
}
