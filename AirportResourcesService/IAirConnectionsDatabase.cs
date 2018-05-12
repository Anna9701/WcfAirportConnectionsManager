using System.Collections.Generic;

namespace AirportResourcesService
{
    public interface IAirConnectionsDatabase
    {
        Dictionary<int, IAirConnection> AirConnections { get; }
        string CsvPath { get; }

        void LoadAirConnections();
    }
}
