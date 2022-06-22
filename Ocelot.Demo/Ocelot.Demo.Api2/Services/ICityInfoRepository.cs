﻿using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// An interface for CityInfoRespository
    /// </summary>
    public interface ICityInfoRepository
    {
        /// <summary>
        /// Responsible for getting a list of Cities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<City>>GetCitiesAsync();

        /// <summary>
        /// Gets cities for pagination
        /// </summary>
        /// <param name="name"></param>
        /// <param name="searchQuery"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery, int pageNum, int pageSize);
        
        /// <summary>
        /// Checks if city exists
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<bool> CityExistsAsync(int cityId);

        /// <summary>
        /// Gets city based with the option of Points of interest
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="includesPointsOfInterest"></param>
        /// <returns></returns>
        Task<City?> GetCityAsync(int cityId, bool includesPointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi);
        Task<bool> SaveChangesAsync();
        void DeletePointOfInterestForCity(PointOfInterest poi);
        Task<bool> CityNameMatchesByCityId(string? cityName, int cityId);
    }
}
