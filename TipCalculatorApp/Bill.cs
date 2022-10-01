namespace TipCalculatorApp
{
    public sealed class Bill
    {
        public double BillAmount { get; set; }
        public int NumberOfPeople { get; set; }
        public double TipPercentage { get; set; }
        public double TipAmount { get; set; }
        public double Total { get; set; }

        public double CalculateTotalPerPerson()
        {
            return BillAmount / NumberOfPeople + TipAmount;
        }
        public double CalculateTipAmount() => (BillAmount / 100 * TipPercentage) / NumberOfPeople;
        

    }
}
