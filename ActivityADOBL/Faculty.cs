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
        public List<CourseDTO> GetCoursByFacName(string facultyName)               //return courses that assigned to specified faculty.
        {
            try
            {
                var courseList = facDALObj.GetCoursesByFacultyName(facultyName);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDTO> GetFacultyNameByCourse(string cTitle)
        {
            try
            {
                var facultyList = facDALObj.GetFacultyByCourseName(cTitle);
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
