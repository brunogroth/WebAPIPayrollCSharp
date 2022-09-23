using System;
using System.ComponentModel.DataAnnotations;
using WebAPIPayrollCSharp.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebAPIPayrollCSharp.Validations{

public class UsingCpf : ValidationAttribute{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext){
        string cpf = (string)value;

        EmployeeContext context = (EmployeeContext)validationContext.GetService(typeof(EmployeeContext));
            Employee result = context.Employees.FirstOrDefault(
                f => f.Cpf.Equals(cpf)
            );
            if(result == null){
                return ValidationResult.Success;
            }
        return new ValidationResult("Employee already exists.");    
        }



        
        }
    }

