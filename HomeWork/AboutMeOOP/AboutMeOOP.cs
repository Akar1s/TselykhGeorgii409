using System;

namespace AboutMeOOP
{
    public class Person
    {
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {FullName}, Age: {Age}");
        }
    }

    public class AboutMe : Person
    {
        public DynamicInfo CurrentInfo { get; set; }

        public AboutMe(string firstName, string lastName, DateTime birthDate, string hobby, string leagoeOfLegendsELO)
            : base(firstName, lastName, birthDate)
        {
            CurrentInfo = new DynamicInfo(hobby, leagoeOfLegendsELO);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Hobby: {CurrentInfo.Hobby}, Leagoe Of Legends ELO: {CurrentInfo.LeagoeOfLegendsELO}");
        }
    }

    public class Gamer : AboutMe
    {
        public string FavoriteGame { get; set; }

        public Gamer(string firstName, string lastName, DateTime birthDate, string hobby, string leagoeOfLegendsELO, string favoriteGame)
            : base(firstName, lastName, birthDate, hobby, leagoeOfLegendsELO)
        {
            FavoriteGame = favoriteGame;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Favorite Game: {FavoriteGame}");
        }
    }

    public class AnimeFan : Gamer
    {
        public string FavoriteAnime { get; set; }

        public AnimeFan(string firstName, string lastName, DateTime birthDate, string hobby, string leagoeOfLegendsELO, string favoriteGame, string favoriteAnime)
            : base(firstName, lastName, birthDate, hobby, leagoeOfLegendsELO, favoriteGame)
        {
            FavoriteAnime = favoriteAnime;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Favorite Anime: {FavoriteAnime}");
        }
    }

    public record struct DynamicInfo(string Hobby, string LeagoeOfLegendsELO);

    public class MyInfo
    {
        public static void AboutMe()
        {
            Person person = new AnimeFan("Имя сокрыто", "Фамилия сокрыта", new DateTime(2006, 5, 10), "Просмотр Аниме", "Emerald 3", "Cyberpunk 2077", "Фрирен провожающая в последний путь");
            person.DisplayInfo();
        }
    }
}