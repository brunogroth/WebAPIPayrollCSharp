using System;
using Microsoft.AspNetCore.Mvc;
using WebAPIPayrollCSharp.Models;
using System.Linq;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Controllers{

    // ********************************************************************************
    // PENDING MIGRATE FROM EMPLOYEES LIST FOR DATABASE
    // ********************************************************************************

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase{

        private readonly EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext context){
            _employeeContext = context;
        }

        //GET at route /api/user/list
        [HttpGet]
        [Route("list")]
        public IActionResult List(){
             return Ok(_employeeContext.Employees.ToList());
        }
        //POST at /api/user/register
         
        [HttpPost]
        [Route("register")] 

        public IActionResult Register( [FromBody] Employee employee){
        _employeeContext.Employees.Add(employee);
        _employeeContext.SaveChanges();
            return Created("", employee);
        }
    
    //
        [HttpGet]
        [Route("list/search/{cpf}")]

        public IActionResult Search([FromRoute] string cpf){

        foreach(Employee registeredEmployee in _employeeContext.Employees){
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
        foreach(Employee registeredEmployee in _employeeContext.Employees){
                if(registeredEmployee.Id == employee.Id){
                    registeredEmployee.Name = employee.Name;
                        _employeeContext.SaveChanges();
                    return Ok(registeredEmployee);
                }
            }
        return NotFound();
        }

        //DELETE: /list/delete/123
        [HttpDelete]
        [Route("list/delete/{id}")]
        public IActionResult Delete([FromRoute] int id){
            Employee employeeFind = null;
                
            foreach(Employee employee in _employeeContext.Employees){
                if(employee.Id == id){
                    employeeFind = employee;
                }
                if(employeeFind != null){
                    _employeeContext.Employees.Remove(employee);
                    _employeeContext.SaveChanges();
                return Ok("Employee successfully deleted!");
                }
            }
            return NotFound();
            }
    }
}