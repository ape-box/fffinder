using System.Collections.Generic;

namespace Engine.Models
{
    public class LocationModel
    {
        public string Location { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
    }
}
