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

        /// <summary>
        /// Gets a list of poi for a city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);

        /// <summary>
        /// Gets city by point of interest
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointOfInterestId"></param>
        /// <returns></returns>
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);

        /// <summary>
        /// Adds point of interest for a given city
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="poi"></param>
        /// <returns></returns>
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi);

        /// <summary>
        /// Returns a bool upon saving changes 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Deletes poi for a given city
        /// </summary>
        /// <param name="poi"></param>
        void DeletePointOfInterestForCity(PointOfInterest poi);

        /// <summary>
        /// Checks if city matches the cityId
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<bool> CityNameMatchesByCityId(string? cityName, int cityId);
    }
}
