using ASTNet.Data;
using ASTNet.Models.DTOs;
using ASTNet.Models.Entity;
using ASTNet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASTNet.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;

            if (!_context.Departments.Any())
            {
                var it = new Department { Name = "IT" };
                var hr = new Department { Name = "HR" };

                _context.Departments.AddRange(it, hr);
                _context.SaveChanges();

                _context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john@test.com",
                        Age = 30,
                        Position = "Developer",
                        DepartmentId = it.Id
                    },
                    new Employee
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane@test.com",
                        Age = 28,
                        Position = "HR Officer",
                        DepartmentId = hr.Id
                    }
                );

                _context.SaveChanges();
            }
        }

        public List<EmployeeDto> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Age = e.Age,
                    Position = e.Position,
                    DepartmentName = e.Department.Name
                })
                .ToList();
        }
    }
}
