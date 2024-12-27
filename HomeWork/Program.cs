using AboutMeOOP;
using HomeWork.Anagram;
using HomeWork.Hierarchy;
using HomeWork.LongestSubstring;
using HomeWork.NumbersFromTheString;
using HomeWork.Palindrome;
using HomeWork.PerimeterAndAreaOfFigure;
using HomeWork.TextCapitalization;
using Microsoft.Extensions.DependencyInjection;
using Debtors;

namespace HomeWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //AnagramClass.Anagram();
            //LongestSubstringClass.LongestSubstring();
            //NumbersFromStringClass.NumbersFromString();
            //PalindromeClass.Palindrome();
            //CapitalizationClass.Capitalization();
            //AboutMeOOP.MyInfo.AboutMe();
            //HierarchyClass.Hierarchy();
            //PerimeterAndArea.PerimeterArea();
            var services = new ServiceCollection();
            services.AddTransient<IGetPartyData, GetPartyData>();
            services.AddTransient<ICreateFileData, CreateFileData>();
            services.AddTransient<ICalculateResult, CalculateResult>();
            services.AddTransient<IOutData, OutData>();
            services.AddTransient<IGetNames, GetNames>();

            var serviceProvider = services.BuildServiceProvider();
            var venueDataStorage = new VenuesDataStorage();

            var menuHandler = new MenuHandler(serviceProvider, venueDataStorage);
            menuHandler.ShowMainMenu();
        }
    }
}
