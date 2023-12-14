namespace InformerRepository.Contract.Models;

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

}
