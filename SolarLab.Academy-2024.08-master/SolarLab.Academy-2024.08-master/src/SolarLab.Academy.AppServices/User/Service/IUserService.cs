using SolarLab.Academy.Contracts.Adverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.User.Service
{
    public interface IUserService
    {
        Task<List<UserShortDto>> Getall(CancellationToken cancellationToken);
        Task<UserShortDto> GetById(Guid id, CancellationToken cancellationToken);
       // Task<UserUpdate> GetByIdforUpdate(Guid id, CancellationToken cancellationToken);
        Task<UserShortDto> AddUser(UserDto user, CancellationToken cancellationToken);
        Task UpdateUser(Guid id,UserUpdate userUpdate, CancellationToken cancellationToken);
        Task DeleteUser(Guid id, CancellationToken cancellationToken);
    }
}
