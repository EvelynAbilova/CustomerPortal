using BLL.LogicServices;
using BOL.CommonEntities;
using BOL.DataBaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsLogic _studentsLogic;
        public StudentsController(IStudentsLogic studentsLogic)
        {
            this._studentsLogic = studentsLogic;
        }

        [HttpGet]
        public IActionResult StudentList()
        
        {
            StudentModule model = new StudentModule();

            List<Students> result = new List<Students>();

            model.studentsList = _studentsLogic.GetStudentsList().ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateStudent()

        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Students FormData)
        {
            string result = _studentsLogic.SaveStudentRecord(FormData);
            if(result == "Saved successfully")
            {
                return RedirectToAction("StudentsList", "Students");
            }
            else
            {
                TempData["ErrorTemp"] = result;
                return RedirectToAction("CreateStudent", "Students");
            }
        }
    }
}
