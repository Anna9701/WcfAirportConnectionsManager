using AirportResourcesService;
using System;
using System.Collections.Generic;

namespace AirportResources
{
    public class AirConnectionsDatabase : IAirConnectionsDatabase
    {
        public Dictionary<int, IAirConnection> AirConnections { get; private set; }
        public string CsvPath { get; private set; }

        private IAirConnectionsReader connectionsReader;

        public AirConnectionsDatabase(string csvPath)
        {
            CsvPath = csvPath;
            connectionsReader = new AirConnectionsReader();
        }

        public void LoadAirConnections()
        {
            AirConnections = connectionsReader.LoadDatabase(CsvPath);
        }
    }
}
