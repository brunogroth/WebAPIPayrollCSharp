using System;
using System.Collections.Generic;
namespace WebAPIPayrollCSharp.Models;

public class Employee{

    public Employee()=> CreatedAt = DateTime.Now;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime Birth { get; set; }
    public DateTime CreatedAt { get; set; }
}