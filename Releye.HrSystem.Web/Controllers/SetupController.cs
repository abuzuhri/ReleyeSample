using GoTech.Framework;
using Releye.HrSystem.Data.Entity;
using Releye.HrSystem.Data.Utils;
using Releye.HrSystem.Service.Model;
using Releye.HrSystem.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Releye.HrSystem.Web.Controllers
{
    public class SetupController : Controller
    {
        SetupUnitOfWork setupService = new SetupUnitOfWork();



        public ActionResult Employee()
        {
            return View();
        }


        public ActionResult EmployeeGrid(EmployeeSearch search)
        {
            
            var list = setupService.getEmployeeList(search);
            return View(list);

        }

        public enum ActionMode
        {
            Add,
            Edit
        }


        public JsonResult AddEditSave(Employee employee, ActionMode Action)
        {
            JsonClientResponse result = new JsonClientResponse();

            try
            {

                ModelState.Remove("ID");
                if (ModelState.IsValid)
                {
                    if (Action == ActionMode.Add)
                    {
                        setupService.AddEmployee(employee);
                    }
                    else
                    {
                        employee = setupService.EmployeeRepository.GetById(employee.ID);
                        TryUpdateModel(employee);
                        setupService.EditEmployee(employee);
                    }
                }

            }
            catch (Exception ex)
            {
                result = new JsonClientResponse(ex);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }



        public ActionResult AddEditEmployee(long? ID)
        {

            ViewBag.ListOfGenders = setupService.getListOfDomains(Constants.DomainKeys.Gender);

            if (ID.HasValue)
            {
                Employee employee = setupService.EmployeeRepository.GetById(ID.Value);
                ViewBag.ActionMode = ActionMode.Edit.ToString();
                return View(employee);
            }
            else
            {
                ViewBag.ActionMode = ActionMode.Add.ToString();
                return View();
            }

        }

        public ActionResult EmployeeDelete(long ID)
        {

            setupService.DeleteEmployee(ID);
            return RedirectToAction("Employee");

        }
    }
}