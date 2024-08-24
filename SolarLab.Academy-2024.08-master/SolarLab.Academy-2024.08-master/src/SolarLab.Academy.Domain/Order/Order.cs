using SolarLab.Academy.Domain.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Info { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = new();
    }
}
