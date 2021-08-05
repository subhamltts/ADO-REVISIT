using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityADODTO;
using ActivityADODAL;

namespace ActivityADOBL
{
    public class Grader
    {
        GraderDAL graderObj;
        public Grader()
        {
            graderObj = new GraderDAL();
        }

        public List<GraderDTO> GetCoursParticipant(string coursID)               //return courses that assigned to specified faculty.
        {
            try
            {
                var participantList = graderObj.GetCourseParticipant(coursID);
                return participantList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> GetCoursOfParticipant(int psno)               //return courses that assigned to specified faculty.
        {
            try
            {
                var coursScoreList = graderObj.GetCoursesOfParticipant(psno);
                return coursScoreList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}