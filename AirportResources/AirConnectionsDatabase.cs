using AirportResourcesService;
using System;
using System.Collections.Generic;

namespace AirportResources
{
    public class AirConnectionsDatabase : IAirConnectionsDatabase
    {
        public IList<IAirConnection> AirConnections { get; private set; }
        public string CsvPath { get; set; }

        private IAirConnectionsReader connectionsReader;

        public AirConnectionsDatabase(string csvPath)
        {
            CsvPath = csvPath;
            connectionsReader = new AirConnectionsReader();
            LoadAirConnections();
        }

        public void LoadAirConnections()
        {
            AirConnections = connectionsReader.LoadDatabase(CsvPath);
        }

        public IList<IAirConnection> GetAirConnections (string portA, string portB)
        {
            IList<IAirConnection> connections = new List<IAirConnection>();

            foreach (var conn in AirConnections)
            {
                if (conn.AirportA.Equals(portA) && conn.AirportB.Equals(portB))
                {
                    connections.Add(conn);
                }
            }

            return connections;
        }
    }
}
