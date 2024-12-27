
using Debtors;


namespace Debtors
{
    public class GetNames : IGetNames
    {
        public Persons MGetNames()
        {
            var friends = DatabaseHelper.LoadDatabase<List<string>>("friends.json") ?? new List<string>();
            return new Persons(friends);
        }
    }
}
