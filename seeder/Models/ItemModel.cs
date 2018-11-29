namespace Seeder.Models
{
    class ItemModel
    {
        public string Item { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
            => $"{Item}: {Price}";
    }
}