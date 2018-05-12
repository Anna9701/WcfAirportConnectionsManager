using System;

namespace AirportResourcesService
{
    public interface IAirConnection
    {
        string AirportA { get; }
        string AirportB { get; }
        DateTime ArrivalTime { get; }
        DateTime DepartureTime { get; }
    }
}
