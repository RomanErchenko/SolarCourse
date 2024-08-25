using AutoMapper;
using SolarLab.Academy.AppServices.Order.Repository;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Domain.Userss;
using SolarLab.Academy.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DataAccess.Context.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SolarLab.Academy.Contracts.Orders;
    using SolarLab.Academy.Domain;
    public class OrderRepository:IOrderRepository
    {

        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderRepository(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDto> AddOrder(Order order, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(order, cancellationToken);


            return _mapper.Map<OrderDto>(order);
        }

        public async Task DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity.Id, cancellationToken);
            }
        }

        public async Task<List<OrderDto>> Getall(CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().ToListAsync(cancellationToken);
            List<OrderDto> user = _mapper.Map<IEnumerable<Order>, List<OrderDto>>(entity);

            return user;
        }

        public async Task<OrderDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(id, cancellationToken);
            OrderDto orderdto = _mapper.Map<OrderDto>(order);
            return orderdto;
        }

        public async Task<OrderDto> GetForUpdate(Guid id, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(id, cancellationToken);
            OrderDto orderdto = _mapper.Map<OrderDto>(order);
            return orderdto;
        }
        public async Task UpdateOrder(Order order, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(order, cancellationToken);

        }







    }
}
