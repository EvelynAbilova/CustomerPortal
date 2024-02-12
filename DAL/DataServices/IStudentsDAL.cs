using BOL.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public interface IStudentsDAL
    {
        List<Students> GetStudentsListDAL();
        string SaveStudentRecordDAL(Students FormData);
    }
}
