using System;
using System.Collections.Generic;

namespace EmployeeProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Employee Processing App");
                var employeeProcessor = new EmployeeProcessor();
                var result = employeeProcessor.ProcessEmployeeRecords(GetSampleData());
                Console.WriteLine("Active Employees: " + string.Join(", ", result.ActiveEmployees));
                Console.WriteLine("Average Salary: " + result.AverageSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

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
                new Employee { Name = "Chrissy Crossy", Status = EmployeeStatus.Active }
            };
        }
    }
}
