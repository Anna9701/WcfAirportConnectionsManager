using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportResources
{
    public class AirConnection : IAirConnection
    {
        public String AirportA { get; private set; }
        public String AirportB { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }

        public AirConnection(string[] columns)
        {
            if (columns.Length < 4)
                return;
            AirportA = columns[0];
            AirportB = columns[1];
            DepartureTime = DateTime.Parse(columns[2]);
            ArrivalTime = DateTime.Parse(columns[3]);
        }
    }
}
