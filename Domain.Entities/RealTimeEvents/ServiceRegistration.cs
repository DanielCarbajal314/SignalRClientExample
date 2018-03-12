using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.RealTimeEvents
{
    public class ServiceRegistration
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string ClientName { get; set; }
    }
}
