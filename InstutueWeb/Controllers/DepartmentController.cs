using InstutueWeb.Data.Dtos;
using InstutueWeb.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstutueWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment departmentDb;

        public DepartmentController(IDepartment departmentDb)
        {
            this.departmentDb = departmentDb;
        }
        public ActionResult Index()
        {
            var departmetns = this.departmentDb.GetDepartmens();
            return View(departmetns);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var department = this.departmentDb.GetDepartmentById(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentAddDto addDto)
        {
            try
            {
                addDto.CreationDate = DateTime.Now;
                addDto.CreationUser = 2;
                this.departmentDb.SaveDepartment(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = this.departmentDb.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentUpdateDto updateDto)
        {
            try
            {
                updateDto.ModifyDate = DateTime.Now;
                updateDto.ModifyUser = 2;
                this.departmentDb.UpdateDepartment(updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
