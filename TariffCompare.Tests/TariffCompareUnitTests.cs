using Xunit;
using TariffCompare.Services;
using TariffCompare.Utils;
using Microsoft.Extensions.Logging;

namespace TariffCompare.Tests
{
    public class TariffCompareUnitTests
    {
        public static ILogger<T> GetLogger<T>()
        {
            return LoggerFactory.Create(x => x.AddConsole()).CreateLogger<T>();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("random")]
        [InlineData("*")]
        [InlineData("1.2.3")]
        public void Check_Input_is_Invalid(string consumptionValue)
        {
            var _tariffService = new TariffService(GetLogger<TariffService>());
            var ex = Assert.Throws<System.ArgumentException>(()=>_tariffService.CheckValidConsumptionValue(consumptionValue));
            
        }

        [Theory]
        [InlineData("500",500)]
        [InlineData("3540.26",3540.26)]
        public void Check_Input_is_Valid(string consumptionValue,double expectedValue)
        {
            var _tariffService = new TariffService(GetLogger<TariffService>());
            double result = _tariffService.CheckValidConsumptionValue(consumptionValue);
            Assert.Equal(expectedValue, result);

        }

        [Theory]
        [InlineData(3500,Constants.PACKAGED_TARIFF_NAME, 800,Constants.BASIC_ELECTRICITY_TARIFF_NAME, 830)]
        [InlineData(4500, Constants.PACKAGED_TARIFF_NAME, 950, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 1050)]
        [InlineData(6000, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 1380, Constants.PACKAGED_TARIFF_NAME, 1400)]
        [InlineData(9000, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 2040, Constants.PACKAGED_TARIFF_NAME, 2300)]
        [InlineData(1501.25, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 390.28, Constants.PACKAGED_TARIFF_NAME, 800)]
        [InlineData(4000,  Constants.PACKAGED_TARIFF_NAME, 800, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 940)]
        [InlineData(100000, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 22060, Constants.PACKAGED_TARIFF_NAME, 29600)]
        [InlineData(55555555.55, Constants.BASIC_ELECTRICITY_TARIFF_NAME, 12222282.22, Constants.PACKAGED_TARIFF_NAME, 16666266.66)]
        public void Compare_Tariff_Products(double consumptionValue, string expectedName1, double expectedValue1, string expectedName2, double expectedValue2)
        {
            var _tariffService = new TariffService(GetLogger<TariffService>());
            using (var products = _tariffService.GetProducts(consumptionValue).GetEnumerator())
            {
                products.MoveNext();
                var productA = products.Current;
                products.MoveNext();
                var productB = products.Current;
                Assert.Equal(expectedName1,productA.Name);
                Assert.Equal(expectedValue1, productA.AnnualCost);
                Assert.Equal(expectedName2,productB.Name);
                Assert.Equal(expectedValue2, productB.AnnualCost);
            }

        }
    }
}