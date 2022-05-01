using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Services;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase 
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
            IMailService mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? 
                throw new ArgumentNullException(nameof(mailService));
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {
            try
            {
                //throw new Exception("Unexplained error!");                
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
                    return NotFound();
                }

                var pointsOfInterestForCity = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);
                return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity)); 

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting points of interest with id {cityId}!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
            
        }

        [HttpGet("{poiId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int poiId)
        {
            try
            {
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    return NotFound();
                }

                // pont of interest
                var poi = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, poiId);
                if (poi == null)
                {
                    _logger.LogInformation($"Point of interest with id {poiId} was not found!");
                    return NotFound();
                }
                return Ok(_mapper.Map<PointOfInterestDto>(poi));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting point of interest with id {poiId}!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto poi)
        {
            try
            {
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    return NotFound();
                }

                var finalPOI = _mapper.Map<PointOfInterest>(poi);

                await _cityInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPOI);
                await _cityInfoRepository.SaveChangesAsync();
                
                var createPointOfInterestRetVal = _mapper.Map<PointOfInterestDto>(finalPOI);

                return CreatedAtRoute("GetPointOfInterest", new
                {
                    cityId = cityId,
                    id = createPointOfInterestRetVal.Id
                },
                createPointOfInterestRetVal);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while creating point of interest!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }

        }

        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest poi)
        {
            var city = await _cityInfoRepository.GetCityAsync(cityId, false);
            if (city != null)
            { 
                city.PointsOfInterest.Add(poi);
            }
        }

        //[HttpPut("{pointofinterestid}")]
        //public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        //{
        //    try
        //    {
        //        var city = _cityDataStore.Cities.FirstOrDefault(c => c.Id != cityId);
        //        if (city == null)
        //        {
        //            _logger.LogCritical($"Point of interest could not be updated with id {cityId}");
        //            return NotFound();
        //        }

        //        // Look for Point Of Interest
        //        var pointOfIntFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
        //        if (pointOfIntFromStore == null)
        //        {
        //            return NotFound();
        //        }
        //        pointOfIntFromStore.Name = pointOfInterest.Name;
        //        pointOfIntFromStore.Description = pointOfInterest.Description;

        //        // This will still return status code 204, albeit with no content
        //        return NoContent();
        //    }

        //    catch (Exception ex)
        //    {
        //        _logger.LogCritical("An error occured while updating point of interest with id {pointOfInterestId}", ex);
        //        return StatusCode(500, "An error occured while handling your request");

        //    }
        //}

        //[HttpPatch("{pointofinterestid}")]
        //public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, 
        //                                                    JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        //{
        //    try
        //    {
        //        var city = _cityDataStore.Cities.FirstOrDefault(c => c.Id != cityId);
        //        if (city == null)
        //        {
        //            _logger.LogCritical($"Point of interest could not be updated with id {cityId}");
        //            return NotFound();
        //        }

        //        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
        //        if (pointOfInterestFromStore == null)
        //        {
        //            _logger.LogCritical($"Point of interest could not be retrieved with id {pointOfInterestId}");
        //            return NotFound();
        //        }

        //        var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
        //        {
        //            Name = pointOfInterestFromStore.Name,
        //            Description = pointOfInterestFromStore.Description
        //        };
        //        patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
        //        // Check if the ModelState is valid
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        //        pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        //        // Return 204 NoContent
        //        return NoContent();
        //    }

        //    catch (Exception ex)
        //    {
        //        _logger.LogCritical("An error occured while updating the point of interest!", ex);
        //        return StatusCode(500, "An error occured while handling your request!");            
        //    }

        //}

        //[HttpDelete("{pointOfInterestId}")]
        //public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        //{
        //    try
        //    {
        //        var city = _cityDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //        if (city == null)
        //        {
        //            _logger.LogCritical($"Point of interest could not be deleted with id {cityId}");
        //            return NotFound();
        //        }

        //        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
        //        if (pointOfInterestFromStore == null)

        //        {
        //            return NotFound();
        //        }
        //        city.PointsOfInterest.Remove(pointOfInterestFromStore);
        //        _mailService.Send("Point of interest is deleted",
        //            $"{pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was successfully deleted!");

        //        // Return 204 NoContent
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogCritical("An error occured while updating the point of interest!", ex);
        //        return StatusCode(500, "An error occured while handling your request!");
        //    }
        //}           
    }
}

