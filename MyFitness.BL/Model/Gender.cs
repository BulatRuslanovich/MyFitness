using System.Runtime.Serialization;

namespace MyFitness.BL.Model
{
    [DataContract]
    public class Gender
    {
        [DataMember]
        public string Name { get; set; }

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
