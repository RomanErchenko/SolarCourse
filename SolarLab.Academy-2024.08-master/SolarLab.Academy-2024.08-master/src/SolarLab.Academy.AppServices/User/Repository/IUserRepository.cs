using SolarLab.Academy.Contracts.Adverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarLab.Academy.Domain.Userss;


namespace SolarLab.Academy.AppServices.User.Repository
{
    using SolarLab.Academy.Domain.Userss;
    public interface IUserRepository
    {
        Task<List<UserShortDto>> Getall(CancellationToken cancellationToken);
        Task<UserShortDto> GetById(Guid id, CancellationToken cancellationToken);
        Task<UserUpdate> GetForUpdate(Guid id, CancellationToken cancellationToken);
        Task<UserShortDto> AddUser(User user,CancellationToken cancellationToken);
        Task UpdateUser(User user,CancellationToken cancellationToken);
        Task DeleteUser(Guid id, CancellationToken cancellationToken);
    }


}

