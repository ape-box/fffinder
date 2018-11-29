using System.Collections.Generic;

namespace Seeder.Models
{
    class Source
    {
        public IEnumerable<string> Brands { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}