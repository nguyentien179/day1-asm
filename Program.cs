using day1_asm;

internal class Program
{
    static List<Car> cars =
    [
        new Car("Tesla", "Model S", 2023, CarType.Electric),
        new Car("Toyota", "Corolla", 2022, CarType.Fuel),
        new Car("Ford", "Mustang Mach-E", 2023, CarType.Electric),
        new Car("Honda", "Civic", 2021, CarType.Fuel),
        new Car("Chevrolet", "Bolt EV", 2023, CarType.Electric),
        new Car("BMW", "i4", 2022, CarType.Electric),
        new Car("Mercedes-Benz", "C-Class", 2023, CarType.Fuel),
        new Car("Nissan", "Leaf", 2022, CarType.Electric),
        new Car("Audi", "e-tron", 2023, CarType.Electric),
        new Car("Hyundai", "Elantra", 2022, CarType.Fuel),
    ];

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nCar Management System");
            Console.WriteLine("1. Add a car");
            Console.WriteLine("2. View all cars");
            Console.WriteLine("3. Search car by Make");
            Console.WriteLine("4. Filter cars by Type");
            Console.WriteLine("5. Remove a car by Model");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddCar();
                    break;
                case "2":
                    ViewAllCars();
                    break;
                case "3":
                    SearchCarByMake();
                    break;
                case "4":
                    FilterCarByType();
                    break;
                case "5":
                    RemoveCarByModel();
                    break;
                case "6":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        void AddCar()
        {
            string make = InputHelper.GetValidatedInput("Enter Make: ");
            string model = InputHelper.GetValidatedInput("Enter Model: ");
            int year = InputHelper.GetValidatedYear();
            CarType type = InputHelper.GetValidatedCarType();

            cars.Add(new Car(make, model, year, type));
            Console.WriteLine("Car added successfully!");
        }

        void ViewAllCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        void SearchCarByMake()
        {
            string make = InputHelper.GetValidatedInput("Enter Make to search: ");
            var results = cars.Where(car =>
                    car.Make.IndexOf(make, StringComparison.OrdinalIgnoreCase) >= 0
                )
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No cars found for this make.");
            }
            else
            {
                foreach (var car in results)
                {
                    Console.WriteLine(car);
                }
            }
        }

        void FilterCarByType()
        {
            Console.WriteLine("Select a car type:");
            CarType selectedType = InputHelper.GetValidatedCarType();

            var results = cars.Where(car => car.Type == selectedType).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("No cars found for this type.");
            }
            else
            {
                foreach (var car in results)
                {
                    Console.WriteLine(car);
                }
            }
        }

        void RemoveCarByModel()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available to remove.");
                return;
            }

            string selectedModel = InputHelper.GetValidatedCarModel(cars);

            cars.RemoveAll(car =>
                car.Model.Equals(selectedModel, StringComparison.OrdinalIgnoreCase)
            );
            Console.WriteLine($"All cars with model '{selectedModel}' have been removed.");
        }
    }
}
