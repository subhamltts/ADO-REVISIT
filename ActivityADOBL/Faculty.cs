using ActivityADODAL;
using ActivityADODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADOBL
{
   public class Faculty
    {
        FacultyDAL facDALObj;
        public Faculty()
        {
            facDALObj = new FacultyDAL();
        }

        public List<FacultyDTO> FetchAllFaculty()
        {
            try
            {
                var facultyList = facDALObj.GetAllFaculty();
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
