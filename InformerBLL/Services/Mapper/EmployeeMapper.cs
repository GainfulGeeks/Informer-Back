using Informer.BLL.Contract.Models;
using Informer.Repository.Contract.Models;

namespace Informer.BLL.Services.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee Map(CreateOrModifyEmployeeDTO dto)
        {
            return new Employee()
            {
                Address = dto.Address,
                Birthdate = dto.Birthdate,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                NationalCode = dto.NationalCode,
                PersonnelCode = dto.PersonnelCode,
                PhoneNumber = dto.PhoneNumber
            };
        }
    }
}