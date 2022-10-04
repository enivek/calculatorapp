using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        private double _total;
        private double _salesTax;
        private int _numberOfPeopleInGroup;
        private string _creditCard;
        private IDictionary<string, double> _creditCards = new Dictionary<string, double>();

        public void SetTotal(double total)
        {
            _total = total;
        }

        public void AddCreditCardFee(string creditCard, double fee)
        {
            _creditCards.Add(creditCard, fee);
        }

        public void SetSalesTax(double salesTax)
        {
            _salesTax = salesTax;  
        }

        public double GetTotal()
        {
            return _total;
        }

        public void SetNumberOfPeopleInGroup(int numberInGroup)
        {
            _numberOfPeopleInGroup = numberInGroup;
        }

        public void SetCreditCard(string creditCard)
        {
            _creditCard = creditCard;
        }

        public double Purchase()
        {
            var result = _total;
            result = result + _salesTax * _total;

            var creditCardFee = 0.0;
            if( !string.IsNullOrWhiteSpace(_creditCard) )
            {
                _creditCards.TryGetValue(_creditCard, out creditCardFee);
            }

            return result + creditCardFee;
        }

    }
}
