using ASTNet.Data;
using ASTNet.Services;
using Microsoft.EntityFrameworkCore;

namespace ASTNet.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void GetEmployeesWithDepartmentName()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeTestDb")
                .Options;

            using var context = new AppDbContext(options);
            var service = new EmployeeService(context);

            var result = service.GetEmployees();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.All(result, e =>
            {
                Assert.False(string.IsNullOrEmpty(e.DepartmentName));
            });
        }
    }
}
