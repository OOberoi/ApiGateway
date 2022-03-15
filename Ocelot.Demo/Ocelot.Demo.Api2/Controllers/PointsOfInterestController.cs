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
        [HttpGet()]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{poiId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int poiId)
        {
            var city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
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
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto poi)
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
        }
    }
}

