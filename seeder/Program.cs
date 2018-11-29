using Newtonsoft.Json;
using Seeder.Models;
using System.IO;
using System.Linq;

namespace Seeder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("configuration.json"));
            var source = JsonConvert.DeserializeObject<Source>(File.ReadAllText("source.json"));
            var generator = new Generator(source, configuration);

            var dataSet = generator.DataSet();

            File.WriteAllText("dataset.json", JsonConvert.SerializeObject(dataSet));
        }
    }
}
