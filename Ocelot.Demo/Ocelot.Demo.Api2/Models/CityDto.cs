namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// A DTO for City with points of interest 
    /// </summary>
    public class CityDto
    {
        /// <summary>
        /// City Id
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// Name of city
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Nullable description of city
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Get a count of no. of interests for a given city
        /// </summary>
        public int NumOfPointsOfInterest {
            get { return PointsOfInterest.Count; }
        }
        /// <summary>
        /// Get a collection of PointsOfInterest
        /// </summary>
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
