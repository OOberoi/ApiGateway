using Microsoft.EntityFrameworkCore;
using Ocelot.Demo.Api2.DB_Context;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _cityInfoContext;

        public CityInfoRepository(CityInfoContext context)
        {
            _cityInfoContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _cityInfoContext.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(string? name, string? searchQuery)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(searchQuery))
            { 
                return await GetCitiesAsync();
            }

            name = name.Trim();
            return await _cityInfoContext.Cities
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        // AnyAsync will return true if a cityId is found and false otherwise
        public async Task<bool> CityExistsAsync(int cityId)
        { 
            return await _cityInfoContext.Cities.AnyAsync( c => c.Id == cityId);
        }

        public async Task<City?> GetCityAsync(int cityId, bool includesPointsOfInterest)
        {
            if (includesPointsOfInterest)
            {
                return await _cityInfoContext.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _cityInfoContext.Cities
                .Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }



        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _cityInfoContext.PointOfInterests
                .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            return await _cityInfoContext.PointOfInterests
                .Where(p => p.CityId == cityId).ToListAsync();
        }

        // Return true when one or more item in the entity are saved
        public async Task<bool> SaveChangesAsync()
        { 
            return (await _cityInfoContext.SaveChangesAsync() >= 0);
        }

        Task ICityInfoRepository.AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi)
        {
            throw new NotImplementedException();
        }

        public void DeletePointOfInterestForCity(PointOfInterest poi)
        {
            _cityInfoContext.PointOfInterests.Remove(poi);
        }
    }
}
