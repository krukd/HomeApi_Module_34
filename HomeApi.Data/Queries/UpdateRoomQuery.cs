using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    public class UpdateRoomQuery
    {
        public string NewName { get; set; }
        public int NewArea { get; set; }
        public bool NewGasConnected { get; set; }
        public int NewVoltage { get; set; }


        public UpdateRoomQuery(string name = null, int area = 0, bool gas = false, int voltage = 0)
        {
            NewName = name;
            NewArea = area;
            NewGasConnected = gas;
            NewVoltage = voltage;
        }

    }
}
