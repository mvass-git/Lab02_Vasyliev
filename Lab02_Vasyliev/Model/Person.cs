using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab02_Vasyliev.Exceptions;
using System.Text.RegularExpressions;

namespace Lab02_Vasyliev.Model
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAdult => CalculateAge() >= 18;
        public string SunSign => CalculateSunSign(DateOfBirth);
        public string ChineseSign => CalculateChineseSign(DateOfBirth);
        public bool IsBirthday => DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - this.DateOfBirth.Year;
            if (DateTime.Today.Month < this.DateOfBirth.Month || (DateTime.Today.Month == this.DateOfBirth.Month && DateTime.Today.Day < this.DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }

        private string CalculateSunSign(DateTime dateOfBirth)
        {
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;

            if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
            {
                return "Pisces";
            }
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else
            {
                return "Capricorn";
            }
            
        }

        private string CalculateChineseSign(DateTime dateOfBirth)
        {
            int startYear = 1924;
            int difference = dateOfBirth.Year - startYear;
            int signIndex = (difference + 11) % 12;

            string[] chineseSigns = {
        "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake",
        "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
    };

            return chineseSigns[signIndex];

        }

        public bool IsBirthDateCorrect()
        {
            if (CalculateAge() > 135)
            {
                throw new PastDateException("Age is impossible");
            }
            else if(this.DateOfBirth > DateTime.Today)
            {
                throw new FutureDateException("Birth date can`t be in the future.");
            }
            return true;
        }

        public bool IsEmailValid()
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if(!Regex.IsMatch(this.Email, pattern))
            {
                throw new InvalidEmailFormatException("Entered e-mail is invalid.");
            }
            return true;
        }
    }
}
