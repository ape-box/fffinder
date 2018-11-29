using Engine.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine
{
    public class ParallelFinderEngine : IFinderEngine
    {
        private readonly IEnumerable<BrandModel> _brands;

        public ParallelFinderEngine(IEnumerable<BrandModel> brands)
        {
            _brands = brands ?? throw new ArgumentNullException(nameof(brands));
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/data-parallelism-task-parallel-library
        // TODO: implement a better one
        public List<ResultModel> FindMenu(string location, string food)
        {
            var searchResults = new ConcurrentBag<ResultModel>();

            Parallel.ForEach(
                _brands,
                (brandModel, loopState, index) =>
                {
                    if (loopState.IsExceptional || loopState.IsStopped || loopState.ShouldExitCurrentIteration)
                    {
                        return;
                    }

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
                });

            return searchResults.ToList();
        }
    }
}