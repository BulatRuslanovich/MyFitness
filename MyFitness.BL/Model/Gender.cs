using System;

namespace MyFitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        
        public string Name { get; }

        public Gender(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым.", nameof(Name));
            }

            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
