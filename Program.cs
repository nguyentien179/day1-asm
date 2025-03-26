using day1_asm;
using day1_asm.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        CarService carService = new CarService();
        try
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
                        carService.AddCar();
                        break;
                    case "2":
                        carService.ViewAllCars();
                        break;
                    case "3":
                        carService.SearchCarByMake();
                        break;
                    case "4":
                        carService.FilterCarByType();
                        break;
                    case "5":
                        carService.RemoveCarByModel();
                        break;
                    case "6":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Main");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }
}
