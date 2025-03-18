using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Models;
using Company.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    //MVC Controller
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        // ASK CLR Create Object From DepartmentRepository
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var department = new Department
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };
                var count = _departmentRepository.Add(department);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")

        {
            if (id is null)
                return BadRequest("Invalid Id"); // 400

            var department = _departmentRepository.Get(id.Value);

            if (department is null)
                return NotFound(new { statusCode = 404, message = $"Department with Id {id} is not found" });

            return View(viewName, department);
        }

        public IActionResult Edit(int? id)
        {
            //if (id is null)
            //    return BadRequest("Invalid Id"); // 400

            //var department = _departmentRepository.Get(id.Value);

            //if (department is null)
            //    return NotFound(new { statusCode = 404, message = $"Department with Id {id} is not found" });

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest(); // 400
                var count = _departmentRepository.Update(department);
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(department);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var department = _departmentRepository.Get(id);
            //if (department is null)
            //    return NotFound(new { statusCode = 404, message = $"Department with Id {id} is not found" });
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest(); // 400
                var count = _departmentRepository.Delete(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

    }
}
