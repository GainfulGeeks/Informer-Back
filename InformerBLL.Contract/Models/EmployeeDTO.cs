namespace Informer.BLL.Contract.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonnelCode { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
