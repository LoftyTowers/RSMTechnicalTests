namespace EmployeeProcessing
{
    public class EmployeeProcessor
    {
        public List<Employee> ProcessEmployeeRecords(List<Employee> employees)
        {
            try
            {
                var activeEmployees = employees.Where(e => e.Status == EmployeeStatus.Active).ToList();
                return activeEmployees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing employee records: {ex.Message}");
                throw new Exception("An error occurred while processing employee records.", ex);
            }
        }

        public double CalculateAverageSalary(List<Employee> employees)
        {
            try
            {
                return employees.Average(e => e.Salary);            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating the average employee salary: { ex.Message }");
                throw new Exception("An error occurred while calculating the average employee salary.", ex);
            }
        }
    }
}