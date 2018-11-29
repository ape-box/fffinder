using System;
using System.Collections.Generic;

namespace Seeder.Models
{
    class BrandModel : Something<string, IEnumerable<LocationModel>, BrandModel>
    {
        public string Brand { get; set; }
        public IEnumerable<LocationModel> Locations { get; set; }

        public BrandModel Create(Func<string> id, Func<IEnumerable<LocationModel>> attr)
        {
            Brand = id.Invoke();
            Locations = attr.Invoke();

            return this;
        }

        public override string ToString()
            => $"{Brand}: [{string.Join(", ", Locations)}]";
    }

    interface Something<Identity, Attributes, Self>
    {
        Self Create(Func<Identity> id, Func<Attributes> attr);
    }
}