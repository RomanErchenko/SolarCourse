using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Contracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Order.Service
{
    using SolarLab.Academy.Domain;
    public interface IOrderService
    {

        Task<List<OrderDto>> Getall(CancellationToken cancellationToken);
        Task<OrderDto> GetById(Guid id, CancellationToken cancellationToken);
       
        Task<OrderDto> AddOrder(OrderDto order, CancellationToken cancellationToken);
        Task UpdateOrder(Guid id,OrderDto order, CancellationToken cancellationToken);
        Task DeleteOrder(Guid id, CancellationToken cancellationToken);


    }
}
