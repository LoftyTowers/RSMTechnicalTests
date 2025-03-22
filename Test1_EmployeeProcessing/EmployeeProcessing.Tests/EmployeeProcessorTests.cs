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

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor correctly filters active employees and calculates the average salary.
        [Test]
        public void ProcessEmployeeRecords_ReturnsActiveEmployees()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.All(e => e.Status == EmployeeStatus.Active), Is.True);
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor returns an empty list and an average salary of 0.0 when no active employees are present.
        [Test]
        public void ProcessEmployeeRecords_ReturnsEmptyListAndZeroAverageSalary()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData().Where(e => e.Status != EmployeeStatus.Active).ToList();

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(0.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // returns an empty list and an average salary of 0.0 when given an empty list.
        [Test]
        public void ProcessEmployeeRecords_ReturnsEmptyListAndZeroAverageSalary_WhenGivenEmptyList()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = new List<Employee>();

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(0.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // handles missing 'status' fields by ignoring such records.
        [Test]
        public void ProcessEmployeeRecords_IgnoresRecordsWithMissingStatusField()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData().Where(e => e.Status != EmployeeStatus.Active).ToList();
            employees.Add(new Employee { Name = "Pete Style", Salary = 65000.0 });

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(0.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // handles missing 'salary' fields by ignoring such records.
        [Test]
        public void ProcessEmployeeRecords_IgnoresRecordsWithMissingSalaryField()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData().Where(e => e.Status != EmployeeStatus.Active).ToList();
            employees.Add(new Employee { Name = "Pete Style", Status = EmployeeStatus.Active });

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(0.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // handles non-numeric 'salary' values by ignoring such records.
        [Test]
        public void ProcessEmployeeRecords_IgnoresRecordsWithNonNumericSalary()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData().Where(e => e.Status != EmployeeStatus.Active).ToList();
            employees.Add(new Employee { Name = "Pete Style", Status = EmployeeStatus.Active, Salary = double.NaN });

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(0.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // correctly returns all employee names and calculates the average salary when all employees are active.
        [Test]
        public void ProcessEmployeeRecords_ReturnsAllEmployeeNamesAndCalculatesAverageSalary_WhenAllEmployeesAreActive()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData().Where(e => e.Status == EmployeeStatus.Active).ToList();

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.Count, Is.EqualTo(employees.Count));
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(employees.Average(e => e.Salary)));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // handles negative salary values correctly when calculating the average.
        [Test]
        public void ProcessEmployeeRecords_HandlesNegativeSalaryValuesCorrectly()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();
            employees[0].Salary = -50000.0;
            employees[1].Salary = -60000.0;

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.All(e => e.Status == EmployeeStatus.Active), Is.True);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(employees.Where(e => e.Status == EmployeeStatus.Active).Average(e => e.Salary)));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // calculates the average salary accurately when salary values have high decimal precision.
        [Test]
        public void ProcessEmployeeRecords_CalculatesAverageSalaryAccurately_WhenSalaryValuesHaveHighDecimalPrecision()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();
            employees[0].Salary = 50000.123456789;
            employees[1].Salary = 60000.987654321;

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.All(e => e.Status == EmployeeStatus.Active), Is.True);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(employees.Where(e => e.Status == EmployeeStatus.Active).Average(e => e.Salary)));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // handles null employee records by ignoring them.
        [Test]
        public void ProcessEmployeeRecords_IgnoresNullEmployeeRecords()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();
            employees.Add(null);

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(employees.Where(e => e != null && e.Status == EmployeeStatus.Active).Average(e => e.Salary)));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // performs efficiently when processing a large number of employee records.
        [Test]
        public void ProcessEmployeeRecords_PerformsEfficiently_WhenProcessingLargeNumberOfEmployeeRecords()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = new List<Employee>();
            for (int i = 0; i < 1000000; i++)
            {
                employees.Add(new Employee { Name = "Employee " + i, Status = EmployeeStatus.Active, Salary = 50000.0 });
            }

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.Count, Is.EqualTo(employees.Count));
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(50000.0));
        }

        // Test that the ProcessEmployeeRecords method on EmployeeProcessor
        // correctly handles employee names containing special characters.
        [Test]
        public void ProcessEmployeeRecords_HandlesEmployeeNamesWithSpecialCharacters()
        {
            // Arrange
            var employeeProcessor = new EmployeeProcessor();
            var employees = GetSampleData();
            employees[0].Name = "John Doe & Co.";
            employees[1].Name = "Jane Smith, Inc.";

            // Act
            var result = employeeProcessor.ProcessEmployeeRecords(employees);

            // Assert
            Assert.That(result.All(e => e.Status == EmployeeStatus.Active), Is.True);
            Assert.That(employeeProcessor.CalculateAverageSalary(result), Is.EqualTo(employees.Where(e => e.Status == EmployeeStatus.Active).Average(e => e.Salary)));
        }
    }
}
