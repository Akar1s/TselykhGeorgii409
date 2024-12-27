namespace Debtors
{
    public class VisitData
    {
        public string Payer { get; }
        public Dictionary<string, int> Names { get; }
        public DateTime VisitDate { get; }

        public VisitData(string payer, Dictionary<string, int> names, DateTime visitDate)
        {
            Payer = payer;
            Names = names;
            VisitDate = visitDate;
        }
    }
}
