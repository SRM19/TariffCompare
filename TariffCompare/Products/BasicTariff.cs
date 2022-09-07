using TariffCompare.Products.Main;
using TariffCompare.Utils;

namespace TariffCompare.Products;
internal class BasicTariff : Product
{
    public BasicTariff()
    {
        Name = Constants.BASIC_ELECTRICITY_TARIFF_NAME;
        Tariff.BaseCost = Constants.BASIC_TARIFF_BASE_PRICE;       
    }

    public BasicTariff SetConsumption(double consumption)
    {
        Tariff.ConsumptionCost = consumption * Constants.BASIC_TARIFF_COST_PER_KWH;
        return this;
    }
}
