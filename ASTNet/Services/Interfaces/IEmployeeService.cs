using ASTNet.Models;
using ASTNet.Models.DTOs;

namespace ASTNet.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployees();
    }
}
