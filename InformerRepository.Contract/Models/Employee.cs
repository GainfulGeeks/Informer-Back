using System.Globalization;

namespace Informer.Repository.Contract.Models;

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string NationalCode { get; set; }

    public string Address { get; set; }

    public DateTime Birthdate { get; set; }

    public string PhoneNumber { get; set; }

    public string PersonnelCode { get; set; }

    public bool Gender { get; set; }

    public void Update(string firstname,string lastname,string natioalCode,string address,DateTime birthdate,string personalCode,
        bool gender)
    {
        FirstName = firstname;
        LastName = lastname;
        NationalCode = natioalCode;
        Address = address;
        Birthdate = birthdate;
        PhoneNumber = personalCode;
        Gender = gender;
    }
}
