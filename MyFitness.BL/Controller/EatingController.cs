using MyFitness.BL.Model;

namespace MyFitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.json";
        private const string EATINGS_FILE_NAME = "eatings.json";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть путым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private List<Food> GetAllFoods()
        {
            var foodDate = Load<Food[]>(FOODS_FILE_NAME);
            if (foodDate != default(Food[]))
            {
                return foodDate.ToList();
            }
            else
            {
                return new List<Food>();
            }
        }

        private void Save()
        {
            base.Save<Food[]>(FOODS_FILE_NAME, Foods.ToArray());
            base.Save<Eating>(EATINGS_FILE_NAME, Eating);
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }
    }
}
