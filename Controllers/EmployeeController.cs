using System;
using Microsoft.AspNetCore.Mvc;
using WebAPIPayrollCSharp.Models;

namespace AspNetCoreWebAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase{
        private static List<Employee> employees = new List<Employee>();
        
        [HttpGet]
        //GET at route /api/user/list
        [Route("list")]
        public IActionResult List(){
            return Ok(employees);
        }
        //POST at /api/user/register
         
        [HttpPost]
        [Route("register")] 

        public IActionResult Register( [FromBody] Employee employee){
        
        employees.Add(employee);
        
            return Created("", employees);
        }
    
    //
        [HttpGet]
        [Route("list/{cpf}")]

        public IActionResult Search([FromRoute] string cpf){

        foreach(Employee registeredEmployee in employees){
            if(registeredEmployee.Cpf == cpf){
                    return Ok(registeredEmployee);
                }
        }
        return NotFound();
        }

        [HttpPut]        
        [Route("list/{OldCpf}/{Cpf}")]
        public bool Edit ([FromRoute] string oldCpf, string cpf){
            //Execute method EditProduct with parameters OldCpf and New Cpf and save the result at variable 'edited' 
        foreach(Employee registeredEmployee in employees){
                if(registeredEmployee.Cpf == oldCpf){
                    registeredEmployee.Cpf = cpf;
                    return true;
                }
            }
        return false;
        }
    }
}