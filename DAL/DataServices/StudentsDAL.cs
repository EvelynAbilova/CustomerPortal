using BOL.DataBaseEntities;
using DAL.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class StudentsDAL : IStudentsDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;

        public StudentsDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }
        public List<Students> GetStudentsListDAL()
        {
            List<Students> students = new List<Students>();

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM public.\"Students\"";
                    students = dbConnection.Query<Students>(SqlQuery, commandType: CommandType.Text).ToList();
                }
            } 
            catch (Exception ex) 
            {
                string msg = ex.Message;
            }

            return students;
        }

        public string SaveStudentRecordDAL(Students FormData)
        {
            string result = string.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    dbConnection.Execute(@"INSERT INTO public.\""Students\"""" (""FirstName"", ""LastName"", ""Email"")VALUES (@FirstName, @LastName, @Email)",
                        new {
                        FirstName = FormData.FirstName, LastName = FormData.LastName, Email = FormData.Email
                        },
                        commandType: CommandType.Text);
                    result = "Saved successfully";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }
    }
}
