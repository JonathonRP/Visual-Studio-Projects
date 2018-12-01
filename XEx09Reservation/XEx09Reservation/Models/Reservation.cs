using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Reservation
{
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int NoOfDays { get; set; }
    public int NoOfPeople { get; set; }
    public string BedType { get; set; }
    public string SpecialRequests { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PreferredMethod { get; set; }
}
