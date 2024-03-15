using System;

namespace permiakov_lab2.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAdult { get; }
        public bool IsBirthday { get; }
        public string ChineseSign { get; }
        public string SunSign { get; }

        public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            ChineseSign = CalculateChineseSign();
            SunSign = CalculateWesternSign();
            IsBirthday = CheckIfBirthday();
            IsAdult = CheckIsAdult();
        }

        public Person(string firstName, string lastName, string emailAddress) : this(firstName, lastName, emailAddress, DateTime.Today)
        { }

        public Person(string firstName, string lastName, DateTime dateOfBirth) : this(firstName, lastName, null, dateOfBirth)
        { }

        private string CalculateWesternSign()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            switch (month)
            {
                case 1 when day >= 20:
                case 2 when day <= 18:
                    return WesternSigns.Aquarius.ToString();
                case 2 when day >= 19:
                case 3 when day <= 20:
                    return WesternSigns.Pisces.ToString();
                case 3 when day >= 21:
                case 4 when day <= 19:
                    return WesternSigns.Aries.ToString();
                case 4 when day >= 20:
                case 5 when day <= 20:
                    return WesternSigns.Taurus.ToString();
                case 5 when day >= 21:
                case 6 when day <= 20:
                    return WesternSigns.Gemini.ToString();
                case 6 when day >= 21:
                case 7 when day <= 22:
                    return WesternSigns.Cancer.ToString();
                case 7 when day >= 23:
                case 8 when day <= 22:
                    return WesternSigns.Leo.ToString();
                case 8 when day >= 23:
                case 9 when day <= 22:
                    return WesternSigns.Virgo.ToString();
                case 9 when day >= 23:
                case 10 when day <= 22:
                    return WesternSigns.Libra.ToString();
                case 10 when day >= 23:
                case 11 when day <= 21:
                    return WesternSigns.Scorpio.ToString();
                case 11 when day >= 22:
                case 12 when day <= 21:
                    return WesternSigns.Sagittarius.ToString();
                default:
                    return WesternSigns.Capricorn.ToString();
            }
        }

        private string CalculateChineseSign()
        {
            int yearOffset = (DateOfBirth.Year - 4) % 12;
            return ((ChineseSigns)yearOffset).ToString();
        }

        private bool CheckIfBirthday()
        {
            DateTime now = DateTime.Today;

            return now.Day == DateOfBirth.Day && now.Month == DateOfBirth.Month;
        }

        private bool CheckIsAdult()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;

            if (DateOfBirth > today.AddYears(-age))
            {
                age--;
            }

            return age >= 18;
        }

        internal enum WesternSigns
        {
            Capricorn,
            Aquarius,
            Pisces,
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
        }

        internal enum ChineseSigns
        {
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig,
        }
    }
}