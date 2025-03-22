namespace EmployeeProcessing
{
    public class EmployeeProcessor
    {
        /// <summary>
        /// Takes in a list of Employees and returns a list of Active Employees.
        /// </summary>
        /// <param name="employees"></param>
        /// <returns>A List of Active Employees</returns>
        /// <exception cref="Exception"></exception>
        public List<Employee> ProcessEmployeeRecords(List<Employee> employees)
        {
            try
            {
                return employees.Where(e => e != null && e.Status == EmployeeStatus.Active && (!double.IsNaN(e.Salary) || e.Salary >= 0)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing employee records: {ex.Message}");
                throw new Exception("An error occurred while processing employee records.", ex);
            }
        }

        /// <summary>
        /// Takes in a list of emplyees and returns the average salary of all employees in the list.
        /// </summary>
        /// <param name="employees"></param>
        /// <returns>double</returns>
        /// <exception cref="Exception"></exception>
        public double CalculateAverageSalary(List<Employee> employees)
        {
            try
            {
                if (employees.Count <= 0)
                {
                    return 0.0;
                }
                return employees.Average(e => e.Salary);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating the average employee salary: {ex.Message}");
                throw new Exception("An error occurred while calculating the average employee salary.", ex);
            }
        }
    }
}