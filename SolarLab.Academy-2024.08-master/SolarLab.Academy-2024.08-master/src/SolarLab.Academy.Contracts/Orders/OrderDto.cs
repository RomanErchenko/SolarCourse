using SolarLab.Academy.Contracts.Adverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Contracts.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Info { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; } = new();
    }
}
