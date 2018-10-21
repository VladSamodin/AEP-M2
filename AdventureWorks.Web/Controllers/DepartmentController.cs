using System.Web.Mvc;
using AdventureWorks.Services.HumanResources;
using AdventureWorks.Web.Attributes;

namespace AdventureWorks.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        [TrackPageGeneration]
        public ActionResult Index()
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentGroups = departmentService.GetDepartments();

            return View(departmentGroups);
        }

        // GET: Departments/Employees/{id}
        [TrackPageGeneration]
        public ActionResult Employees(int id)
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentEmployees = departmentService.GetDepartmentEmployees(id);
            var departmentInfo = departmentService.GetDepartmentInfo(id);

            ViewBag.Title = "Employees in " + departmentInfo.Name + " Department";

            return View(departmentEmployees);
        }
    }
}
