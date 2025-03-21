using System.ComponentModel.DataAnnotations;

namespace EmployeeProcessing
{
    public class Employee
    {
        public required string Name { get; set; }
        public EmployeeStatus Status { get; set; }
        public double Salary { get; set; }
    }

    public enum EmployeeStatus
    {
        Unknown = 0,
        Active = 10,
        Inactive = 20
    }   
}