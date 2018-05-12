using AirportResourcesService;
using System;
using System.Collections.Generic;

namespace AirportResources
{
    public class AirConnectionsDatabase : IAirConnectionsDatabase
    {
        public IList<IAirConnection> AirConnections { get; private set; }
        private ISet<string> Airports { get;  set; }
        public string CsvPath { get; set; }

        private IAirConnectionsReader connectionsReader;

        public AirConnectionsDatabase(string csvPath)
        {
            CsvPath = csvPath;
            Airports = new HashSet<string>();
            connectionsReader = new AirConnectionsReader();
            LoadAirConnections();
        }

        public void LoadAirConnections()
        {
            AirConnections = connectionsReader.LoadDatabase(CsvPath);
            foreach(var conn in AirConnections)
            {
                Airports.Add(conn.AirportA);
                Airports.Add(conn.AirportB);
            }
        }

        public bool ContainsAirport(string name)
        {
            return Airports.Contains(name);
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

        public IList<IAirConnection> GetAirConnections (string portA, string portB, DateTime departureTime, DateTime arrivalTime)
        {
            IList<IAirConnection> allConnections = GetAirConnections(portA, portB);
            IList<IAirConnection> connections = new List<IAirConnection>();
            foreach (var conn in allConnections)
            {
                if (departureTime >= conn.DepartureTime && departureTime < conn.ArrivalTime)
                    if (arrivalTime > conn.DepartureTime && arrivalTime <= conn.ArrivalTime)
                        connections.Add(conn);
            }
            return connections;
        }
    }
}
