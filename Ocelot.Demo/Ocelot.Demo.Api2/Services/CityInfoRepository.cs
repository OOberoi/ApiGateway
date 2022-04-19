﻿using Microsoft.EntityFrameworkCore;
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
            return await _cityInfoContext.Cities.ToListAsync();
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
