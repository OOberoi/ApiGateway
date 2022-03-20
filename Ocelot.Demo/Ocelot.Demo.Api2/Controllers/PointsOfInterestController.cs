using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            try
            {
                //throw new Exception("Unexplained error!");

                var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} was not found when accessing points of interest!");
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting points of interest with id {cityId}!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
            
        }

        [HttpGet("{poiId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int poiId)
        {
            try
            {
                var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"Point of interest with id {poiId} was not found!");
                    return NotFound();
                }

                // pont of interest
                var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == poiId);
                if (poi == null)
                {
                    return NotFound();
                }
                return Ok(poi);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting point of interest with id {poiId}!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
        }
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto poi)
        {
            try
            {
                var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    return NotFound();
                }

                // This block of code can be removed if you want an explicit error description defined in data validation
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // get the max value from poi
                var maxPoiId = CitiesDataStore.Instance.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

                var pointOfInterest = new PointOfInterestDto()
                {
                    Id = ++maxPoiId,
                    Name = poi.Name,
                    Description = poi.Description
                };

                city.PointsOfInterest.Add(pointOfInterest);

                return CreatedAtRoute("GetPointOfInterest",
                    new
                    {
                        cityId = cityId,
                        pointOfInterestId = pointOfInterest.Id
                    },
                    pointOfInterest);
            }

            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while creating point of interest!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
            
        }

        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        { 
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id != cityId);
            if (city == null)
            {
                return NotFound();
            }            

            // Look for Point Of Interest
            var pointOfIntFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfIntFromStore == null)
            {
                return NotFound();
            }
            pointOfIntFromStore.Name = pointOfInterest.Name;
            pointOfIntFromStore.Description = pointOfInterest.Description;

            // This will still return status code 204, albeit with no content
            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, 
                                                            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        { 
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id != cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            { 
                 Name =pointOfInterestFromStore.Name,
                 Description = pointOfInterestFromStore.Description
            };
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
            // Check if the ModelState is valid
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            // Return 204 NoContent
            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        { 
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault( c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault( c => c.Id==pointOfInterestId);
            if (pointOfInterestFromStore == null)

            {
                return NotFound();
            }
            city.PointsOfInterest.Remove(pointOfInterestFromStore);
            // Return 204 NoContent
            return NoContent();
        }
    }
}

