using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIPayrollCSharp.Validations;
namespace WebAPIPayrollCSharp.Models;

public class Folha{
    public Folha()=> CreatedAt = DateTime.Now;
    public int folhaId {get; set;}
    public double valorHora {get; set;}
    public double quantidadeHoras { get; set; }
    public double salarioBruto {get; set;}
    public double impostoRenda { get; set; }
    public double impostoInss {get; set;}
    public double impostoFGTS {get; set;}
    public double salarioLiquido { get; set; }

    [ForeignKey("Employee")]
    [Column("employeeId")]
    public int employeeId {get; set;}
    public virtual Employee Employee {get; set;}
    public DateTime CreatedAt { get; set; }

}
