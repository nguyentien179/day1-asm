using System;

namespace day1_asm;

public class InputHelper
{
    public static string GetValidatedInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid value.");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    public static int GetValidatedYear()
    {
        int year;
        while (true)
        {
            Console.Write("Enter Year: ");
            if (
                int.TryParse(Console.ReadLine(), out year)
                && year > 1885
                && year <= DateTime.Now.Year
            )
            {
                return year;
            }
            Console.WriteLine(
                "Invalid year. Please enter a valid year between 1886 and the current year."
            );
        }
    }

    public static CarType GetValidatedCarType()
    {
        var carTypes = Enum.GetValues(typeof(CarType)).Cast<CarType>().ToList();
        Console.WriteLine("Select a car type:");
        for (int i = 0; i < carTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {carTypes[i]}");
        }

        while (true)
        {
            Console.Write("Enter the number corresponding to the type: ");
            if (
                int.TryParse(Console.ReadLine(), out int choice)
                && choice > 0
                && choice <= carTypes.Count
            )
            {
                return carTypes[choice - 1];
            }
            Console.WriteLine("Invalid selection. Please choose a valid number.");
        }
    }

    public static string GetValidatedCarModel(List<Car> cars)
    {
        var models = cars.Select(car => car.Model).Distinct().ToList();

        Console.WriteLine("Select a car model:");
        for (int i = 0; i < models.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {models[i]}");
        }

        int choice;
        while (true)
        {
            Console.Write("Enter the number corresponding to the model: ");
            if (
                int.TryParse(Console.ReadLine(), out choice)
                && choice > 0
                && choice <= models.Count
            )
            {
                return models[choice - 1];
            }
            Console.WriteLine("Invalid selection. Please enter a valid number from the list.");
        }
    }
}
