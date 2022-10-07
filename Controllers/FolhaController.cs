using System;
using Microsoft.AspNetCore.Mvc;
using WebAPIPayrollCSharp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AspNetCoreWebAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class FolhaController : ControllerBase{
    private readonly EmployeeContext _context;
    public FolhaController(EmployeeContext context){
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult List(){
             return Ok(_context.Folha.ToList());
    }

    [HttpPost]
    [Route("registrar")] 
    public IActionResult Register( [FromBody] Folha folha){

    double salarioBruto = folha.quantidadeHoras * folha.valorHora;
    folha.salarioBruto = salarioBruto;
    folha = calculaImpostos(folha);

    _context.Folha.Add(folha);
    _context.SaveChanges();
        return Created("", folha);
    }
        
    [HttpGet]
    [Route("buscar")]
    public IActionResult Search(String cpf, int mes, int ano){
        Folha folhaEncontrada = null;
        Folha folhaDoCpfEncontrado = null;

        //pesquisa CPF
        foreach(Employee employee in _context.Employees){
            if(cpf == employee.Cpf){
                folhaDoCpfEncontrado = _context.Folha.Find(employee.Id);   
            }
        }
        
        //Pesquisa Mês e Ano
        foreach(Folha folha in _context.Folha){    
        if(mes == folha.CreatedAt.Month){
            folhaEncontrada = folha;
        }else if(ano == folha.CreatedAt.Year){
            folhaEncontrada = folha;
        }
        }

        //Retornos
        if(folhaDoCpfEncontrado != null){
            return Ok(folhaDoCpfEncontrado);
        }
        if(folhaEncontrada != null){
            return Ok(folhaEncontrada);
        }

        return NotFound();
    }
    
    [HttpGet]
    [Route("filtrar")]
    public IActionResult filter(int mes, int ano){
        ArrayList folhas = new ArrayList();
        
        foreach(Folha folha in _context.Folha){
            if(folha.CreatedAt.Month == mes && folha.CreatedAt.Year == ano){
                folhas.Add(folha);
            } 
        }

        if(folhas != null){
        return Ok(folhas);
        }

        return NotFound();
    }

    //Método para cálculo de impostos
    protected Folha calculaImpostos(Folha folha){
        double salarioBruto = folha.salarioBruto;
        double INSS = 0;
        double IR = 0;
        double FGTS = 0;
        
        // Cálculo IR
        if(salarioBruto >= 1903.98 && salarioBruto <=2826.55){
            IR = salarioBruto * 0.075;        
        } else if(salarioBruto <= 3751.05){
            IR = (salarioBruto * 0.15) - 142.80;
        } else if(salarioBruto <= 4664.68){
            IR = (salarioBruto * 0.225) - 354.80;
        } else if(salarioBruto > 4664.68){
            IR = (salarioBruto * 0.275) - 869.36;
        }

        // Cálculo INSS
        if(salarioBruto <= 1693.72){
            INSS = salarioBruto * 0.08;
        } else if(salarioBruto <= 2822.90){
            INSS = salarioBruto * 0.09;
        } else if(salarioBruto <= 5645.80){
            INSS = salarioBruto * 0.11;
        } else{
            INSS = 621.03;
        }

        //Calculo FGTS
        FGTS = salarioBruto * 0.08; 
         
        double salarioLiquido = folha.salarioBruto - INSS;
        salarioLiquido = salarioLiquido - IR;

        //Definição de valores no objeto
        folha.impostoInss = INSS;
        folha.impostoRenda = IR;
        folha.impostoFGTS = FGTS;
        folha.salarioLiquido = salarioLiquido;

        //Retorno
        return folha;
    }
    }

}

