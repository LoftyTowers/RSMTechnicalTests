using NUnit.Framework;
using EmployeeProcessing;
using Employee;

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
                new Employee { Name = "Chrissy Crossy", Status = EmployeeStatus.Inactive },
                new Employee { Name = "Chrissy Crossy", Status = EmployeeStatus.Unknown }
            };

        [Test]
        public void CalculateEmployeeSalary_ValidEmployee_ReturnsExpectedSalary()
        {
            // Arrange
            var employee = new Employee { Name = "John", HourlyRate = 20, HoursWorked = 40 };
            var processor = new EmployeeProcessor();

            // Act
            var salary = processor.CalculateSalary(employee);

            // Assert
            Assert.AreEqual(800, salary);
        }

        // test that the CalculateSalary method returns the expected salary for an employee with an hourly rate of 0
        [Test]
        public void CalculateEmployeeSalary_HourlyRateZero_ReturnsZero()
        {
            // Arrange
            var employee = new Employee { Name = "John", HourlyRate = 0, HoursWorked = 40 };
            var processor = new EmployeeProcessor();

            // Act
            var salary = processor.CalculateSalary(employee);

            // Assert
            Assert.AreEqual(0, salary);
        }
    }
}
