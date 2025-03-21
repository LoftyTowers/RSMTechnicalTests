namespace EmployeeProcessing
{
    public class EmployeeProcessor
    {
        public (List<string> ActiveEmployees, double AverageSalary) ProcessEmployeeRecords(List<Employee> employees)
        {
            var activeEmployees = employees.Where(e => e.Status == EmployeeStatus.Active).Select(e => e.Name).ToList();
            var averageSalary = employees.Average(e => e.Salary);
            return (activeEmployees, averageSalary);
        }
    }
}