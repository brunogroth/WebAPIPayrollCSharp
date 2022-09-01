namespace WebAPIPayrollCSharp.Models;

public class Employee{

    public Employee()=> CreatedAt = DateTime.Now;
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime Birth { get; set; }
    public DateTime CreatedAt { get; set; }
}