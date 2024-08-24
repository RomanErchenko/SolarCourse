using AutoMapper;
using SolarLab.Academy.AppServices.Repository;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.Adverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.User.Service
{
    using SolarLab.Academy.Domain.Userss;
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async  Task<UserShortDto> AddUser(UserDto user, CancellationToken cancellationToken)
        {
            User userdto = _mapper.Map<User>(user);
           await _userRepository.AddUser(userdto, cancellationToken);
            UserShortDto us = _mapper.Map<UserShortDto>(userdto);
            return us;
        }

        public async Task DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(id, cancellationToken);
            
        }

        public async Task<List<UserShortDto>> Getall(CancellationToken cancellationToken)
        {
          return await _userRepository.Getall(cancellationToken);
            
        }

        public async Task<UserShortDto> GetById(Guid id, CancellationToken cancellationToken)
        {
           return await _userRepository.GetById(id, cancellationToken);
        }

        public async Task UpdateUser(Guid id,UserUpdate userpdate, CancellationToken cancellationToken)
        {
           var user=await _userRepository.GetForUpdate(id, cancellationToken);

             user=userpdate;

            User userdto = _mapper.Map<User>(user);

            await _userRepository.UpdateUser(userdto, cancellationToken);

            
           
        }
    }
}
