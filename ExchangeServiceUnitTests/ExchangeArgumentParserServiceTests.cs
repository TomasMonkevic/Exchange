using NUnit.Framework;

using Exchange.Entity;
using System.Collections.Generic;
using System;

namespace Exchange.Service.UnitTests
{
    public class ExchangeArgumentParserServiceTests
    {
        private const string WRONG_ARGUMENT_FORMAT_EXCEPTION_MESSAGE = "Incorrect argument format.\nUsage - 'Exchange EUR/DKK 12345.6789'\n";

        private ExchangeArgumentParserService _exchangeArgumentParserService;

        [SetUp]
        public void Setup() 
        {
            _exchangeArgumentParserService = new ExchangeArgumentParserService(new ExchangeEntityFactory());
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            yield return new TestCaseData(new string[] { "EUR/DKK", "1.5" }, new ExchangePair(TestData.EUR, TestData.DKK, 1.5m), "");
            yield return new TestCaseData(new string[] { "EUR/DKK", "123,456,789.0123" }, new ExchangePair(TestData.EUR, TestData.DKK, 123456789.0123m), "");
            yield return new TestCaseData(new string[] { "EUR/DKK", "number" }, null, WRONG_ARGUMENT_FORMAT_EXCEPTION_MESSAGE);
            yield return new TestCaseData(new string[] { "EUR/DKK", "12 345,6789" }, null, WRONG_ARGUMENT_FORMAT_EXCEPTION_MESSAGE);
            yield return new TestCaseData(new string[] { "EUR DKK", "12 345,6789" }, null, WRONG_ARGUMENT_FORMAT_EXCEPTION_MESSAGE);
            yield return new TestCaseData(new string[] { "EURO/DKK", "1" }, null, WRONG_ARGUMENT_FORMAT_EXCEPTION_MESSAGE);
        }

        [Test]
        [TestCaseSource("TestCaseSourceData")]
        public void ArgumentsToExchangePairTests(string[] args, IExchangePair expectedExchangePair, string expectedException)
        {
            try
            {
                var actualExchangePair = _exchangeArgumentParserService.ArgumentsToExchangePair(args);
                Assert.IsTrue(actualExchangePair.MainCurrency.Iso == expectedExchangePair.MainCurrency.Iso,
                    $"Expected {expectedExchangePair.MainCurrency.Iso}, actual {actualExchangePair.MainCurrency.Iso}");
                Assert.IsTrue(actualExchangePair.MoneyCurrency.Iso == expectedExchangePair.MoneyCurrency.Iso,
                    $"Expected amount should be {expectedExchangePair.MoneyCurrency.Iso}, but actual is {actualExchangePair.MoneyCurrency.Iso}");
                Assert.IsTrue(actualExchangePair.Amount == expectedExchangePair.Amount,
                    $"Expected amount should be {expectedExchangePair.Amount}, but actual is {actualExchangePair.Amount}");
                Assert.IsTrue(string.IsNullOrEmpty(expectedException));
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == expectedException, $"Expected exception should be \"{expectedException}\", but actual is \"{e.Message}\"");
            }
        }
    }
}