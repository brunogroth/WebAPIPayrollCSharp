using System;
using Microsoft.AspNetCore.Mvc;
using WebAPIPayrollCSharp.Models;
using System.Linq;

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
        [Route("list/search/{cpf}")]

        public IActionResult Search([FromRoute] string cpf){

        foreach(Employee registeredEmployee in employees){
            if(registeredEmployee.Cpf == cpf){
                    return Ok(registeredEmployee);
                }
        }
        return NotFound();
        }

        [HttpPut]        
        [Route("edit")]
        public IActionResult Edit ([FromBody] Employee employee){
            //Execute method EditProduct with parameters OldCpf and New Cpf and save the result at variable 'edited' 
        foreach(Employee registeredEmployee in employees){
                if(registeredEmployee.Cpf == employee.Cpf){
                    registeredEmployee.Name = employee.Name;
                    return Ok(registeredEmployee);
                }
            }
        return NotFound();
        }

        //DELETE: /list/delete/123
        [HttpDelete]
        [Route("list/delete/{cpf}")]
        public IActionResult Delete([FromRoute] string cpf){
            
            foreach(Employee employee in employees){
 if(employee != null){
            employees.Remove(employee);
            return Ok(employee);
        }
        }
            return NotFound();
            }
    }
}