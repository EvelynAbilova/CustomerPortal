using BOL.DataBaseEntities;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        private readonly IStudentsDAL _studentsDAL;

        public StudentsLogic(IStudentsDAL studentsDAL)
        {
            this._studentsDAL = studentsDAL;
        }

        public List<Students> GetStudentsList()
        {
            List<Students> result = new List<Students>();

            result = _studentsDAL.GetStudentsListDAL();

            return result;
        }

        public string SaveStudentRecord(Students FormData)
        {
            string result = string.Empty;

            if (String.IsNullOrWhiteSpace(FormData.FirstName) && String.IsNullOrWhiteSpace(FormData.LastName) && String.IsNullOrWhiteSpace(FormData.Email))
            {
                result = "Please fill all fields";
                return result;
            }


            result = _studentsDAL.SaveStudentRecordDAL(FormData);

            if (result == "Saved successfully")
            {
                return result;
            }
            else
            {
                result = "An error occurred. Try again";
                return result;

            }
        }
    }
}
