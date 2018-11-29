using System.Collections.Generic;

namespace Engine.Models
{
    public class BrandModel
    {
        public string Brand { get; set; }
        public IEnumerable<LocationModel> Locations { get; set; }
    }
}
