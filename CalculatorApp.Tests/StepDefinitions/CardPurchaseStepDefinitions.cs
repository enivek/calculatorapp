using System;
using TechTalk.SpecFlow;

namespace CalculatorApp.Tests.StepDefinitions
{
    [Binding]
    public class CardPurchaseStepDefinitions
    {
        private ICalculator calculator = new Calculator();
        private double _chargeAmount;

        [Given(@"a user makes an order with a total price of \$(.*)")]
        public void GivenAUserMakesAnOrderWithATotalPriceOf(int p0)
        {
            calculator.SetTotal(p0);
        }

        [Given(@"the sales tax is (.*)%")]
        public void GivenTheSalesTaxIs(double p0)
        {
            calculator.SetSalesTax(p0/100);
        }

        [Given(@"a credit card fee table")]
        public void GivenACreditCardFeeTable(Table table)
        {
            for(int i = 0; i < table.RowCount; i++)
            {
                var row = table.Rows[i];
                var creditCardName = row[0].ToString();
                var creditCardFee = row[1].ToString();
                var creditCardFeeDouble = Convert.ToDouble(creditCardFee.Substring(1));
                calculator.AddCreditCardFee(creditCardName, creditCardFeeDouble);
            }
        }

        [Given(@"the user pays with a ""([^""]*)"" credit card")]
        public void GivenTheUserPaysWithACreditCard(string creditCard)
        {
            calculator.SetCreditCard(creditCard);
        }

        [When(@"the user attempts to make a purchase")]
        public void WhenTheUserAttemptsToMakeAPurchase()
        {
            _chargeAmount = calculator.Purchase();
        }

        [Then(@"the user should be charged \$(.*)")]
        public void ThenTheUserShouldBeCharged(double p0)
        {
            Assert.AreEqual(p0, _chargeAmount);
        }
    }
}
