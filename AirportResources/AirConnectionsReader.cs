using AirportResourcesService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportResources
{
    public class AirConnectionsReader : IAirConnectionsReader
    {
        public Dictionary<int, IAirConnection> LoadDatabase(String path)
        {
            Dictionary<int, IAirConnection> airConnections = new Dictionary<int, IAirConnection>();
            var csvRows = File.ReadAllLines(path, Encoding.Default).ToList();
            int i = 0;
            foreach (var row in csvRows.Skip(1))
            {
                var columns = row.Split(',');
                AirConnection airData = new AirConnection(columns);
                airConnections.Add(i++, airData);
            }
            return airConnections;
        }

    }
}
