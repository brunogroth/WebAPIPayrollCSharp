using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPIPayrollCSharp.Validations;
namespace WebAPIPayrollCSharp.Models;

public class Employee{

    public Employee()=> CreatedAt = DateTime.Now;
    public int Id { get; set; }
    [Required(
        ErrorMessage ="Name is required!"
    )]
    public string Name { get; set; }
    [Required(
        ErrorMessage ="CPF is required!"
    )]
    [UsingCpf]
    [StringLength(11, MinimumLength = 11 , ErrorMessage = "CPF must be 11 characters!")]
    public string Cpf { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email!")]
    public string Email {get; set;}
    [Range (0,1000, ErrorMessage = "Maximum wage is USD$ 1.000,00")]
    public double Wage {get; set;}
    public DateTime Birth { get; set; }
    public DateTime CreatedAt { get; set; }
    
}