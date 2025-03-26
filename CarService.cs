using System;
using day1_asm.Helpers;

namespace day1_asm;

public class CarService
{
    private List<Car> cars =
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

    public void AddCar()
    {
        try
        {
            string make = InputHelper.GetValidatedInput("Enter Make: ");
            string model = InputHelper.GetValidatedInput("Enter Model: ");
            int year = InputHelper.GetValidatedYear();
            CarType type = InputHelper.GetValidatedCarType();

            cars.Add(new Car(make, model, year, type));
            Console.WriteLine("Car added successfully!");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "AddCar");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }

    public void ViewAllCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("No cars available.");
            return;
        }

        try
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ViewAllCars");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }

    public void SearchCarByMake()
    {
        try
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
        catch (Exception ex)
        {
            Logger.LogError(ex, "SearchCarByMake");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }

    public void FilterCarByType()
    {
        try
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
        catch (Exception ex)
        {
            Logger.LogError(ex, "FilterCarByType");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }

    public void RemoveCarByModel()
    {
        try
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
        catch (Exception ex)
        {
            Logger.LogError(ex, "RemoveCarByModel");
            Console.WriteLine("An error occurred. Please try again.");
        }
    }
}
