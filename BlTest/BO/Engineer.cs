﻿

using DO;

namespace BlTest.BO;

public class Engineer
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public EngineerExperience Level { get; set; }
    public double Cost { get; set; }

    public override string ToString() => this.ToStringProperty();
    string ToStringProperty()
    {
        return $"Id: {Id}, Name:{Name}, Email:{Email}, Level:{Level}, Cost:{Cost}";
    }
}