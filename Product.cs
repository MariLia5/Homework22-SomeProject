namespace SomeProject
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbs { get; set; }
        public int Calories { get; set; }

        public Product() { }

        public Product(string name, int prot, int fats, int carbs, int calories)
        {
            ProductName = name;
            Proteins = prot;
            Fats = fats;
            Carbs = carbs;
            Calories = calories;
        }

        public Product(int id, string name, int prot, int fats, int carbs, int calories)
            : this(name, prot, fats, carbs, calories)
        {
            Id = id;
        }
    }
}
