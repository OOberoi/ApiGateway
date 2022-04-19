using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        public CityInfoRepository()
        {

        }
        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City?> GetCityAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
