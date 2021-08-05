using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityADODTO;
using ActivityADODAL;

namespace ActivityADOBL
{
   public class Course
    {
        CourseDAL courseDALObj;
        public Course()                        //Constructor
        {
            courseDALObj = new CourseDAL();
        }

        public List<CourseDTO> FetchAllCourses()       //Get All Faculties from DB
        {
            try
            {
                var courseList = courseDALObj.GetAllCourses();
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDTO> FetchCoursesByName(string courseTitle)
        {
            try
            {
                var courseList = courseDALObj.GetCoursesByName(courseTitle);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDTO> FetchCoursesByAssessmentMode(string assessmentMode)
        {
            try
            {
                var courseList = courseDALObj.GetCoursesByAssesmentMode(assessmentMode);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
