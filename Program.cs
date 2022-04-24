namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            DietFactory DietFactory = new DietFactory();
            Dictionary<String, Object> data = new Dictionary<string, object>();
            Vegan vegan = DietFactory.Get(DietType.Vegan, data) as Vegan;
            Vegetarian vegetarian = DietFactory.Get(DietType.Vegetarian, data) as Vegetarian;
            Omnivore omnivore = DietFactory.Get(DietType.Omnivore, data) as Omnivore;
            //
            bool breakloop = false;
            //
            while (!breakloop)
            {
                Console.WriteLine(@"
_____________________Menu_______________________
Please enter a Diet name from the following list:
(-)Vegan
(-)Vegetarian
(-)Omnivore
(-)Type 'q' to exit ");
                //
                var userChoice = Console.ReadLine().ToLower();
                if (userChoice == "q" )
                {
                    breakloop = true;
                }
                //
                switch (userChoice)
                {
                    case "vegan":
                        Console.WriteLine(vegan.GetInfo());
                        Console.ReadKey();
                        break;
                    case "vegetarian":
                        Console.WriteLine(vegetarian.GetInfo());
                        Console.ReadKey();
                        break;
                    case "omnivore":
                        Console.WriteLine(omnivore.GetInfo());
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("<!> You did not type name from the menu. Please try again <!>");
                        break;
                }
            }
        }
        //
        interface IObject
        {
            String GetInfo();
        }
        //
        class Vegan : IObject
        {
            public String Name;
            public String Food;

            public virtual String GetInfo()
            {
                return String.Format($"\nDiet name: {Name}. \nOn a {Name} diet, you can eat foods including: \n{Food}.");
            }
        }
        //
        class Vegetarian : IObject
        {
            public String Name;
            public String Food;
            public virtual String GetInfo()
            {
                return String.Format($"\nDiet name: {Name}. \nOn a {Name} diet, you can eat foods including: \n{Food}.");
            }
        }
        //
        class Omnivore : IObject
        {
            public String Name;
            public String Food;
            public virtual String GetInfo()
            {
                return String.Format($"\nDiet name: {Name}. \nOn a {Name} diet, you can eat foods including: \n{Food}.");
            }
        }

        enum DietType
        {
            Vegan,
            Vegetarian,
            Omnivore
        }

        class DietFactory
        {
            DietType _type;
            Dictionary<String, Object> _data;
            public IObject Get(DietType type, Dictionary<String, Object> data)
            {
                _type = type;
                _data = data;
                return GetDiet();
            }

            public IObject GetDiet()
            {
                IObject diet = null;
                switch (_type)
                {
                    case DietType.Vegan:
                        diet = new Vegan() { Name = "Vegan", Food = "- Fruits and vegetables,\n- Nuts and seeds,\n- Legumes such as peas, beans,\n- Breads, rice, and pasta,\n- Dairy alternatives such as soymilk, coconut milk, and almond milk" };
                        break;

                    case DietType.Vegetarian:
                        diet = new Vegetarian() { Name = "Vegetarian", Food = "- Fruits and vegetables,\n- Nuts and seeds,\n- Breads, rice, and pasta,\n- Proteins such as tofu, seitan and dairy products" };
                        break;

                    case DietType.Omnivore:
                        diet = new Omnivore() { Name = "Omnivore", Food = "- Fruits and vegetables,\n- Nuts and seeds,\n- Legumes such as peas, beans,\n- Breads, rice, and pasta,\n- Meat, Fish and Eggs" };
                        break;
                }
                return diet;
            }
        }
    }
}