using System.Collections.Generic;

namespace AirportResourcesService
{
    public interface IAirConnectionsDatabase
    {
        IList<IAirConnection> AirConnections { get; }
        string CsvPath { get; }

        void LoadAirConnections();
        IList<IAirConnection> GetAirConnections(string portA, string portB);
        bool ContainsAirport(string name);
    }
}
