using DataHolding.DataBase;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using DataHolding.Models;
using DataHolding.Models.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;


namespace DataHolding.Controllers
{
    // inject the dbcontext here for working with DB.....

    public class Employees : Controller
    {
        private readonly EmployeeContext employeeDbContext;

        public Employees(EmployeeContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<EmployeeRecord> obj = employeeDbContext.EmployeeRecords.ToList();
                return View(obj);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeRecord recordRequest)
        {
            // Check if the submitted data is valid
            if (ModelState.IsValid)
            {
                recordRequest.Dob = DateTime.UtcNow;
                // Add the record to the DbSet
                employeeDbContext.EmployeeRecords.Add(recordRequest);

                // Save changes to the database
                employeeDbContext.SaveChanges();

                // Redirect to the "Index" action after successful save
                return RedirectToAction("Index");
            }

            // ModelState is not valid, return the current view with validation errors
            return View();
        }

        public IActionResult ShowData()
        {
           return View(); 
        }
    }
}
