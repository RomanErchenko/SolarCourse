using AutoMapper;
using SolarLab.Academy.AppServices.Order.Repository;
using SolarLab.Academy.AppServices.User.Repository;
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
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> AddOrder(OrderDto order, CancellationToken cancellationToken)
        {
            Order orderdto = _mapper.Map<Order>(order);
            await _orderRepository.AddOrder(orderdto, cancellationToken);
            OrderDto us = _mapper.Map<OrderDto>(orderdto);
            return us;
        }

        public async Task DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrder(id, cancellationToken);

        }

        public async Task<List<OrderDto>> Getall(CancellationToken cancellationToken)
        {
            return await _orderRepository.Getall(cancellationToken);

        }

        public async Task<OrderDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetById(id, cancellationToken);
        }

        public async Task UpdateOrder(Guid id, OrderDto orderupdate, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetForUpdate(id, cancellationToken);

            order = orderupdate;

            Order userdto = _mapper.Map<Order>(order);

            await _orderRepository.UpdateOrder(userdto, cancellationToken);



        }

    }
}
