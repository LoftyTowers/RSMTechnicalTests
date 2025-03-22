using NUnit.Framework;
using EmployeeProcessing;

namespace EmployeeProcessing.Tests
{
    [TestFixture]
    public class EmployeeProcessorTests
    {

        static List<Employee> GetSampleData()
        {
            return new List<Employee> {
                new Employee { Name = "John Doe", Status = EmployeeStatus.Active, Salary = 50000.0 },
                new Employee { Name = "Jane Smith", Status = EmployeeStatus.Inactive, Salary = 60000.0 },
                new Employee { Name = "Alice Brown", Status = EmployeeStatus.Active, Salary = 70000.0 },
                new Employee { Name = "Bob Johnson", Status = EmployeeStatus.Active, Salary = 50000.0 },
                new Employee { Name = "Eve White", Status = EmployeeStatus.Inactive, Salary = 65000.0 },
                new Employee { Name = "Fred Bjornson", Status = EmployeeStatus.Unknown, Salary = 50000.0 },
                new Employee { Name = "Maggy Ince", Status = EmployeeStatus.Inactive, Salary = 60000.0 },
                new Employee { Name = "Janni Pink", Status = EmployeeStatus.Active, Salary = 70000.0 },
                new Employee { Name = "Rob Fredrick", Status = EmployeeStatus.Unknown, Salary = 50000.0 },
                new Employee { Name = "Stacy Stinson", Status = EmployeeStatus.Inactive, Salary = 65000.0 },
                new Employee { Name = "Pete Style", Salary = 65000.0 },
                new Employee { Name = "Chrissy Crossy", Status = EmployeeStatus.Active },
                new Employee { Name = "Sam Plant", Status = EmployeeStatus.Inactive },
                new Employee { Name = "Rich Screen", Status = EmployeeStatus.Unknown }
            };
        }

        // test that the CalculateAverageSalary method on EmployeeProcessor returns the expected average salary for all employees
        [Test]
        public void CalculateAverageSalary_ReturnsExpectedAverageSalary()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();

            // Act
            var result = employeeProcessor.CalculateAverageSalary(employees);

            // Assert
            Assert.Equals(employees.Average(e => e.Salary), result);
        }
    }
}
