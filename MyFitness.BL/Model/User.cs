using System;

namespace MyFitness.BL.Model
{
    [Serializable]  
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        private int GetAge()
        {
            DateTime nowDate = DateTime.Now;
            int Age = nowDate.Year - BirthDate.Year;

            if (BirthDate > nowDate.AddYears(-Age))
            {
                Age--;
            }

            return Age;
        }
        

        public User(string Name, Gender Gender, DateTime BirthDate, double Weight, double Height)
        {
            #region Data Check
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(Name));
            }

            if (Gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым!", nameof(Gender));
            }

            if (BirthDate < DateTime.Parse("01.01.1900") || BirthDate > DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата!", nameof(BirthDate));
            }

            if (Weight <= 0)
            {
                throw new ArgumentNullException("Отрицательный вес!", nameof(Weight));
            }

            if (Height <= 0)
            {
                throw new ArgumentNullException("Отрицательный рост!", nameof(Height));
            }
            #endregion

            this.Name = Name;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Weight = Weight;
            this.Height = Height;
        }

        public User(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(Name));
            }

            this.Name = Name;
        }

        public override string ToString()
        {
            return Name + " " + GetAge();
        }

    }
}
