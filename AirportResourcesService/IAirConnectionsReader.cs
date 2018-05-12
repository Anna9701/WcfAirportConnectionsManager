using System.Collections.Generic;

namespace AirportResourcesService
{
    public interface IAirConnectionsReader
    {
        Dictionary<int, IAirConnection> LoadDatabase(string path);
    }
}
