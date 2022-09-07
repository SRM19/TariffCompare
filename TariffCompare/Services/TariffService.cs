using Microsoft.Extensions.Logging;
using TariffCompare.Products;
using TariffCompare.Products.Main;
using TariffCompare.Services.IServices;

namespace TariffCompare.Services
{
    internal class TariffService : ITariffService
    {
        private readonly ILogger<TariffService> _logger;

        public TariffService(ILogger<TariffService> logger)
        {
            _logger = logger;
        }
        public IEnumerable<Product> GetProducts(double consumption)
        {
            try
            {
                List<Product> products = new();
                products.Add(new BasicTariff().SetConsumption(consumption).GetAnnualCost());
                products.Add(new PackagedTariff().SetConsumption(consumption).GetAnnualCost());
                return products.OrderBy(p => p.AnnualCost).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public double CheckValidConsumptionValue(string enteredValue)
        {
            try
            {
                if (enteredValue.Length <= 0)
                    throw new ArgumentException("Please pass the consumption value");

                double consumption;
                bool validArgument = double.TryParse(enteredValue, out consumption);

                if (!validArgument || consumption <= 0)
                    throw new ArgumentException("Please pass a valid consumption value");
                return consumption;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
