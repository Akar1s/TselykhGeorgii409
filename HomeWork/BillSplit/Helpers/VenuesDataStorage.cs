
namespace Debtors
{
    public class VenuesDataStorage : IVenuesDataStorage
    {
        public Dictionary<string, List<VisitData>> VenueVisits { get; set; } = new();
        public Dictionary<string, Dictionary<string, int>> VenuesData { get; set; } = new();

        public void AddVenue(PartyData partyData, DateTime visitDate)
        {
            if (!VenuesData.ContainsKey(partyData.Payer))
            {
                VenuesData[partyData.Payer] = new Dictionary<string, int>(partyData.Names);
            }
            else
            {
                foreach (var name in partyData.Names)
                {
                    if (VenuesData[partyData.Payer].ContainsKey(name.Key))
                    {
                        VenuesData[partyData.Payer][name.Key] += name.Value;
                    }
                    else
                    {
                        VenuesData[partyData.Payer][name.Key] = name.Value;
                    }
                }
            }
            if (!VenueVisits.ContainsKey(partyData.VenueName))
            {
                VenueVisits[partyData.VenueName] = new List<VisitData>();
            }
            VenueVisits[partyData.VenueName].Add(new VisitData(partyData.Payer, partyData.Names, visitDate));
        }
    }
}