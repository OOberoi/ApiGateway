﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Services;
using Ocelot.Demo.Api2.Entities;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            try
            {
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    return NotFound();
                }

                // Look for Point Of Interest
                var poi = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
                
                if (poi == null)
                {
                    return NotFound();
                }

                _mapper.Map(pointOfInterest, poi);
                await _cityInfoRepository.SaveChangesAsync();

                // This will still return status code 204, albeit with no content
                return NoContent();
            }

            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while updating point of interest with id {pointOfInterestId}", ex);
                return StatusCode(500, "An error occured while handling your request");
            }
        }

        [HttpPatch("{pointofinterestid}")]
        public async Task<ActionResult> PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
                                                            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            try
            {
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    return NotFound();
                }

                var poi = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
                if (poi == null)
                {
                    return NotFound();
                }

                var poiPatch = _mapper.Map<PointOfInterestForUpdateDto>(poi);
                                
                patchDocument.ApplyTo(poiPatch, ModelState);
                // Check if the ModelState is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(poiPatch))
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(poiPatch, poi);
                await _cityInfoRepository.SaveChangesAsync();

                // Return 204 NoContent
                return NoContent();
            }

            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while updating the point of interest!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }

        }

        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            try
            {
                if (!await _cityInfoRepository.CityExistsAsync(cityId))
                {
                    return NotFound();
                }

                var poi = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
                if (poi == null)

                {
                    return NotFound();
                }

                _cityInfoRepository.DeletePointOfInterestForCity(poi);
                await _cityInfoRepository.SaveChangesAsync();

                _mailService.Send("Point of interest is deleted",
                    $"{poi.Name} with id {poi.Id} was successfully deleted!");

                // Return 204 NoContent
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while updating the point of interest!", ex);
                return StatusCode(500, "An error occured while handling your request!");
            }
        }
    }
}

