using TariffCompare.Products.Main;

namespace TariffCompare.Services.IServices
{
    internal interface ITariffService
    {
        IEnumerable<Product> GetProducts(double consumption);

        double CheckValidConsumptionValue(string consumption);
    }
}
