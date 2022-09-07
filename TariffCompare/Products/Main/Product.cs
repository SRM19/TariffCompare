using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffCompare.Products.Main;
internal abstract class Product
{
    public string Name { get; set; }

    public double AnnualCost { get; set; }

    protected CostDistribution Tariff = new() { BaseCost = 0, ConsumptionCost = 0 };
    public virtual Product GetAnnualCost()
    {
        AnnualCost = Math.Round(Tariff.BaseCost + Tariff.ConsumptionCost, 2);
        return this;
    }

}
internal class CostDistribution
{
    public double BaseCost { get; set; }
    public double ConsumptionCost { get; set; }
}


