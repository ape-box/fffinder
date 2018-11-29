using Seeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seeder
{
    class Generator
    {
        public Source Source { get; }
        public Source SourceSelection { get; }
        public Configuration Configuration { get; }

        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        public Generator(Source source, Configuration configuration)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            SourceSelection = new Source
            {
                Brands = Pick(Configuration.Brands.Quantity, Source.Brands),
                Locations = Pick(Configuration.Locations.Quantity, Source.Locations),
                Items = Pick(Configuration.Items.Quantity, Source.Items)
            };
        }

        public List<BrandModel> DataSet() => Brands().ToList();

        #region Builder Methods
        public IEnumerable<BrandModel> Brands()
            => InfiniteStream<BrandModel>()
                .Select(Fill)
                .Take(Configuration.Brands);

        public IEnumerable<LocationModel> Locations()
            => InfiniteStream<LocationModel>()
                .Select(Fill)
                .Take(Configuration.Locations);

        public IEnumerable<ItemModel> Items()
            => InfiniteStream<ItemModel>()
                .Select(Fill)
                .Take(Configuration.Items);
        #endregion

        #region Fill Methods
        private BrandModel Fill(BrandModel model)
        {
            model.Brand = Pick(SourceSelection.Brands);
            model.Locations = Locations();

            return model;
        }

        private LocationModel Fill(LocationModel model)
        {
            model.Location = Pick(SourceSelection.Locations);
            model.Items = Items();

            return model;
        }

        private ItemModel Fill(ItemModel model)
        {
            model.Item = Pick(SourceSelection.Items);
            model.Price = Price();

            return model;
        }
        #endregion

        #region Helpers Methods
        private decimal Price()
            => decimal.Round(
                Configuration.Prices.Calculate(_random.NextDouble()),
                2);

        private IEnumerable<T> Pick<T>(decimal quantity, IEnumerable<T> list)
            => list.OrderBy(_ => _random.Next(0, int.MaxValue)).Take((int)quantity).ToList();

        private T Pick<T>(IEnumerable<T> list)
            => list.ElementAt(_random.Next(0, list.Count() - 1));

        private IEnumerable<T> InfiniteStream<T>()
            where T : new()
        {
            while (true)
            {
                yield return new T();
            }
        }
        #endregion
    }
}
