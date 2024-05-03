using CoreTestApplication.Data;
using CoreTestApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model) 
        {
            if(ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name= model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Country = model.Country,
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty Field can't submit";
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Name = emp.Name, Gender = emp.Gender, Email = emp.Email, Country = emp.Country
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                Gender = model.Gender,
                Email = model.Email,
                Country = model.Country
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";

            return RedirectToAction("Index");
        }
    }
}
