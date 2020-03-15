using NUnit.Framework;

using Exchange.Entity;
using System.Collections.Generic;
using System;

namespace Exchange.Service.UnitTests
{
    public class ExchangeServiceTests
    {
        private ExchangeService _echangeService;
        private MockExchangeRates _mockExchangeRates;

        [SetUp]
        public void Setup()
        {
            _echangeService = new ExchangeService();
            _mockExchangeRates = new MockExchangeRates();
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            yield return new TestCaseData(new ExchangePair(TestData.eur, TestData.dkk, 1.0m), 7.4394m, "");
            yield return new TestCaseData(new ExchangePair(TestData.dkk, TestData.usd, 6.63m), 0.999m, "");
            yield return new TestCaseData(new ExchangePair(TestData.eur, TestData.usd, 1.0m), 1.121m, "");
            yield return new TestCaseData(new ExchangePair(TestData.eur, TestData.eur, 104.0m), 104.0m, "");
            // Would be nice to have a custom exception type but to save time only exception message will do
            yield return new TestCaseData(new ExchangePair(TestData.LTL, TestData.eur, 104.0m), 104.0m, "Currency not found");
        }

        bool AreEqual(decimal a, decimal b, decimal tolerance = 0.001m)
        {
            return Math.Abs(a - b) < tolerance;
        }

        [Test]
        [TestCaseSource("TestCaseSourceData")]
        public void CalculateMoneyCurrencyAmountTest(IExchangePair exchangePair, decimal expectedAmount, string expectedException)
        {
            try
            {
                var actualAmount = _echangeService.CalculateMoneyCurrencyAmount(_mockExchangeRates, exchangePair);
                Assert.IsTrue(AreEqual(actualAmount, expectedAmount), $"Expected amount should be {expectedAmount}, but actual is {actualAmount}");
                Assert.IsTrue(string.IsNullOrEmpty(expectedException));
            }
            catch(Exception e)
            {
                Assert.IsTrue(e.Message == expectedException, $"Expected exception should be \"{expectedException}\", but actual is \"{e.Message}\"");
            }
        }
    }
}