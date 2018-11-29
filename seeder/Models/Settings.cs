namespace Seeder.Models
{
    class Settings
    {
        public decimal Quantity { get; set; }
        public decimal Distribution { get; set; }

        private decimal Min => Quantity - Mid;
        private decimal Mid => Quantity * Distribution;

        public decimal Calculate(double pick)
            => Min + Mid * (decimal)pick;

        public static implicit operator int(Settings settings)
            => (int) settings.Quantity;
    }
}