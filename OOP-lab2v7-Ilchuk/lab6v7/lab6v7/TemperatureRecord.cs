public class TemperatureRecord
{
    public string Day { get; set; }
    public double Celsius { get; set; }

    public TemperatureRecord(string day, double celsius)
    {
        Day = day;
        Celsius = celsius;
    }
}

}
