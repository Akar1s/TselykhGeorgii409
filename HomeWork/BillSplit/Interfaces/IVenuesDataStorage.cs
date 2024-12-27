
    namespace Debtors
    {
        public interface IVenuesDataStorage
        {
            Dictionary<string, List<VisitData>> VenueVisits { get; set; }
            Dictionary<string, Dictionary<string, int>> VenuesData { get; set; }

            void AddVenue(PartyData partyData, DateTime visitDate);
        }
    }

