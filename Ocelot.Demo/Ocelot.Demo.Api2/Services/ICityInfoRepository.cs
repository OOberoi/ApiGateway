using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services

{
    public interface ICityInfoRepository
    {
        IEnumerable<City>GetCities();

    }
}
