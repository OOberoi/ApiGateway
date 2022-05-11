using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>>GetCitiesAsync();
        Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery, int pageNum, int pageSize);
        Task<bool> CityExistsAsync(int cityId);
        Task<City?> GetCityAsync(int cityId, bool includesPointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi);
        Task<bool> SaveChangesAsync();
        void DeletePointOfInterestForCity(PointOfInterest poi);
    }
}
