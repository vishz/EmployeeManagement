namespace EmployeeManagement.Models
{
  public class Employee
  {
    public int Id { get; set; }
    public string No { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }

    // Navigation property
    public Department Department { get; set; }
  }
}
