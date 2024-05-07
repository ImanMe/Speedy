namespace SpeedyAir.Models;

public class Flight
{
    public int Number { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public int Day { get; set; }
    public IList<Order> AssignedOrders { get; set; } = new List<Order>();

    public Flight(int number, string departureCity, string arrivalCity, int day)
    {
        Number = number;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        Day = day;
    }

    public override string ToString()
    {
        return $"Flight: {Number}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
    }
}