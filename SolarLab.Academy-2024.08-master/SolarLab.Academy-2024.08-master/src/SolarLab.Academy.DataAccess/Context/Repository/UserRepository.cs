using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Domain.Advert;
using SolarLab.Academy.Domain.Userss;
using SolarLab.Academy.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DataAccess.Context.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserRepository(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserShortDto> AddUser(User user, CancellationToken cancellationToken)
        {
           await _repository.AddAsync(user, cancellationToken);


            return _mapper.Map<UserShortDto>(user);
        }

        public async Task DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity != null) 
            {
              await  _repository.DeleteAsync(entity.Id,cancellationToken);
            }
        }

        public async Task<List<UserShortDto>> Getall(CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().ToListAsync(cancellationToken);
            List<UserShortDto> user = _mapper.Map<IEnumerable<User>, List<UserShortDto>>(entity);

            return user;
        }

        public async Task<UserShortDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            var user= await _repository.GetByIdAsync(id, cancellationToken);
            UserShortDto userdto = _mapper.Map<UserShortDto>(user);
            return userdto;
        }

        public async Task<UserUpdate> GetForUpdate(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(id, cancellationToken);
            UserUpdate userdto = _mapper.Map<UserUpdate>(user);
            return userdto;
        }
        public async Task UpdateUser(User user, CancellationToken cancellationToken)
        {
           await _repository.UpdateAsync(user, cancellationToken);
           
        }
    }
}
