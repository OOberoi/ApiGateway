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
        public string? Description { get; set; }
        public int NumOfPointsOfInterest {
            get { return PointsOfInterest.Count; }
        }
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
