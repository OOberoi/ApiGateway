using Microsoft.EntityFrameworkCore;
using Ocelot.Demo.Api2.DB_Context;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// A repository class for City Info
    /// </summary>
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _cityInfoContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CityInfoRepository(CityInfoContext context)
        {
            _cityInfoContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// A task that returns a list of cities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _cityInfoContext.Cities.OrderBy(c => c.Name).ToListAsync();
        }
               
        //Tuple (a language construct to return multiple values) - by adding pagination metadata
        public async Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery, int pageNum, int pageSize)
        {
            // This block of code is not required anymore!
            //if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(searchQuery))
            //{ 
            //    return await GetCitiesAsync();
            //}

            // collection
            var col = _cityInfoContext.Cities as IQueryable<City>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                col = col.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                col = col.Where(n => n.Name.Contains(searchQuery) || (n.Description != null && n.Description.Contains(searchQuery)));
            }

            var totItemCnt = await col.CountAsync();

            // construct pagination data
            var paginationMetadata = new PaginationMetadata(totItemCnt, pageSize, pageNum);

            var colRetVal = await col.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToListAsync();

            return (colRetVal, paginationMetadata); 
        }

        /// <summary>
        /// AnyAsync will return true if a cityId is found and false otherwise
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<bool> CityExistsAsync(int cityId)
        {
            return await _cityInfoContext.Cities.AnyAsync(c => c.Id == cityId);
        }

        /// <summary>
        /// Get city by id
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="includesPointsOfInterest"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method that checks for city's existence
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<bool> IsCityExistsAsync(string? cityName, int cityId)
        { 
            return await _cityInfoContext.Cities.AnyAsync(c => c.Id == cityId && c.Name == cityName);   
        }

        /// <summary>
        /// Returns Points of Interest object for a given city
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointOfInterestId"></param>
        /// <returns></returns>
        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _cityInfoContext.PointOfInterests
                .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of points of interest for a given city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            return await _cityInfoContext.PointOfInterests
                .Where(p => p.CityId == cityId).ToListAsync();
        }

        /// <summary>
        /// Returns true when one or more items in the entity are saved
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _cityInfoContext.SaveChangesAsync() >= 0);
        }

        Task ICityInfoRepository.AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes points of interest
        /// </summary>
        /// <param name="poi"></param>
        public void DeletePointOfInterestForCity(PointOfInterest poi)
        {
            _cityInfoContext.PointOfInterests.Remove(poi);
        }

        public Task<bool> CityNameMatchesByCityId(string? cityName, int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
