namespace Debtors
{
    public class PartyData
    {
        public string VenueName { get; set; }
        public string Payer { get; set; }
        public Dictionary<string, int> Names { get; set; } = new();

        public PartyData(string venueName, string payer)
        {
            VenueName = venueName;
            Payer = payer;
        }
    }
}
