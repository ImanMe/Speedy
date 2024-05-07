namespace SpeedyAir.Models;

public class FlightItinerary
{
    public FlightItinerary(string orderId, int? flightNumber, string departureCity, string arrivalCity, int? day)
    {
        OrderId = orderId;
        FlightNumber = flightNumber;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        Day = day;
    }

    public FlightItinerary(string orderId)
    {
        OrderId = orderId;
    }

    public string OrderId { get; set; }
    public int? FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public int? Day { get; set; }

    public override string ToString()
    {
        if (FlightNumber == null && string.IsNullOrEmpty(DepartureCity) && string.IsNullOrEmpty(ArrivalCity) &&
            Day == null)
            return $"order: {OrderId}, flightNumber: not scheduled";
        return
            $"order: {OrderId}, flightNumber: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
    }
}