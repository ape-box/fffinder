using System.Collections.Generic;

namespace Seeder.Models
{
    class LocationModel
    {
        public string Location { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }

        public override string ToString()
            => $"{Location}: [{string.Join(", ", Items)}]";
    }
}