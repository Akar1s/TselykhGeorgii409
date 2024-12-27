namespace Debtors
{
    public class CalculateResult : ICalculateResult
    {
        public void GetCalculatedResult(IVenuesDataStorage venueDataStorage)
        {
            var dictionary = venueDataStorage.VenuesData;

            foreach (var externalKey in dictionary.Keys.ToList())
            {
                foreach (var internalKey in dictionary[externalKey].Keys.ToList())
                {
                    if (dictionary.ContainsKey(internalKey) && dictionary[internalKey].ContainsKey(externalKey))
                    {
                        var payerAmount = dictionary[externalKey][internalKey];
                        var debtorAmount = dictionary[internalKey][externalKey];

                        if (payerAmount < debtorAmount)
                        {
                            dictionary[internalKey][externalKey] -= payerAmount;
                            dictionary[externalKey].Remove(internalKey);
                        }
                        else if (payerAmount > debtorAmount)
                        {
                            dictionary[externalKey][internalKey] -= debtorAmount;
                            dictionary[internalKey].Remove(externalKey);
                        }
                        else
                        {
                            dictionary[externalKey].Remove(internalKey);
                            dictionary[internalKey].Remove(externalKey);
                        }
                    }
                }
            }
        }
    
    }
}