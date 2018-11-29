using Engine.Models;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class NaiveFinderEngine : IFinderEngine
    {
        private readonly IEnumerable<BrandModel> _brands;

        public NaiveFinderEngine(IEnumerable<BrandModel> brands)
        {
            _brands = brands ?? throw new ArgumentNullException(nameof(brands));
        }

        public List<ResultModel> FindMenu(string location, string food)
        {
            var searchResults = new List<ResultModel>();

            foreach (var brandModel in _brands)
            {
                foreach (var locationModel in brandModel.Locations)
                {
                    if (string.Equals(locationModel.Location, location, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (var itemModel in locationModel.Items)
                        {
                            if (string.Equals(itemModel.Item, food, StringComparison.OrdinalIgnoreCase))
                            {
                                searchResults.Add(new ResultModel
                                {
                                    Brand = brandModel.Brand,
                                    Location = locationModel.Location,
                                    Item = itemModel.Item,
                                    Price = itemModel.Price
                                });
                            }
                        }
                    }
                }
            }

            return searchResults;
        }
    }
}