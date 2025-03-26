using System;

namespace day1_asm;

public class Car(string make, string model, int year, CarType type)
{
    public string Make { get; set; } = make;
    public string Model { get; set; } = model;
    public int Year { get; set; } = year;
    public CarType Type { get; set; } = type;

    public override string ToString()
    {
        return $"{Year} {Make} {Model} - {Type}";
    }
}
