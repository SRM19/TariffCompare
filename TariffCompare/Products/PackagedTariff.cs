using TariffCompare.Products.Main;
using TariffCompare.Utils;

namespace TariffCompare.Products;
internal class PackagedTariff : Product
{
    public PackagedTariff()
    {
        Name = Constants.PACKAGED_TARIFF_NAME;
        Tariff.BaseCost = Constants.PACKAGED_TARIFF_BASE_PRICE;
        
    }

    public PackagedTariff SetConsumption(double consumption)
    {
        Tariff.ConsumptionCost = (consumption > Constants.PACKAGED_TARIFF_LIMIT ? 
                                  consumption - Constants.PACKAGED_TARIFF_LIMIT : 0)
                                  * Constants.PACKAGED_TARIFF_COST_PER_KWH;
        return this;
    }
}
