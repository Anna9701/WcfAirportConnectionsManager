﻿using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirportResources
{
    [DataContract]
    public class AirConnection : IAirConnection
    {
        [DataMember]
        public String AirportA { get; private set; }
        [DataMember]
        public String AirportB { get; private set; }
        [DataMember]
        public DateTime DepartureTime { get; private set; }
        [DataMember]
        public DateTime ArrivalTime { get; private set; }

        public AirConnection(string[] columns)
        {
            if (columns.Length < 4)
                return;
            AirportA = columns[0].Trim();
            AirportB = columns[1].Trim();
            DepartureTime = DateTime.Parse(columns[2]);
            ArrivalTime = DateTime.Parse(columns[3]);
        }
    }
}
