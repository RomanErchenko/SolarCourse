using AutoMapper;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Contracts.Orders;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Domain.Advert;
using SolarLab.Academy.Domain.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DataAccess.MapProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
           // CreateMap<Order, OrderDto>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserShortDto>();
                 
        }




    }
}
