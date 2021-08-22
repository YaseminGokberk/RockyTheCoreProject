using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationTypeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _dbContext.ApplicationType;
            return View(objList);
        }

        // GET for Create
        public IActionResult Create()
        {
            return View();
        }

        // POST for Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _dbContext.ApplicationType.Add(obj);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET for Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbContext.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST for Edit
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            //check Model Validations is valid  - server side validation
            if (ModelState.IsValid)
            {
                _dbContext.ApplicationType.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        // GET for Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbContext.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST for Delete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.ApplicationType.Remove(obj);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
