using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffCompare.Utils;
public static class Constants
{
    public const string BASIC_ELECTRICITY_TARIFF_NAME = "Basic electricity tariff";

    public const string PACKAGED_TARIFF_NAME = "Packaged tariff";

    public const int BASIC_TARIFF_BASE_PRICE = 60; //(5€ per month * 12)

    public const int PACKAGED_TARIFF_BASE_PRICE = 800;

    public const double BASIC_TARIFF_COST_PER_KWH = 0.22;

    public const double PACKAGED_TARIFF_COST_PER_KWH = 0.30;

    public const int PACKAGED_TARIFF_LIMIT = 4000;

    public const int TABLE_WIDTH = 75;
}

