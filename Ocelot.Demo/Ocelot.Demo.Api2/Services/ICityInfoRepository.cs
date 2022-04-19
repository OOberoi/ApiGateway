using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services

{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>>GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includesPointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
    }
}
