using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    public class DeleteDeviceRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
