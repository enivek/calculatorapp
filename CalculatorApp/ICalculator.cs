namespace CalculatorApp
{
    public interface ICalculator
    {
        public void SetTotal(double total);

        public void AddCreditCardFee(string creditCard, double fee);

        public void SetCreditCard(string creditCard);

        public void SetSalesTax(double salesTax);

        public double GetTotal();

        public void SetNumberOfPeopleInGroup(int numberInGroup);

        public double Purchase();
    }
}
