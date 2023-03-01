using InventoryService.Model;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var msg = context.Message;
            await Console.Out.WriteAsync(msg.Details);
        }
    }
}
