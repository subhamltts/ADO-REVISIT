using ActivityADODTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADODAL
{
   public class GraderDAL
    {
        SqlConnection sqlConnection;

        public GraderDAL()                                 //Class Constructor
        {
            sqlConnection = DatabaseConn.ConnectToDB();     //Call static ConnectToDB() from DBConnection class to establish conn
        }

        public List<GraderDTO> GetCourseParticipant(string courseID)
        {
            List<GraderDTO> lstGrade = new List<GraderDTO>();
            SqlCommand cmd;
            try
            {
                string query = @"SELECT Marks_Obtained,ParticipantID FROM Grader WHERE CourseID='" + courseID + "'";
                cmd = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    lstGrade.Add(
                        new GraderDTO
                        {
                            ParticipantID = Convert.ToInt32(dataReader["ParticipantID"].ToString()),
                            Marks_Obtained = Convert.ToInt32(dataReader["Marks_Obtained"].ToString())
                        });
                }
                return lstGrade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<GraderDTO> GetCoursesOfParticipant(int psno)
        {
            List<GraderDTO> lstCours = new List<GraderDTO>();
            SqlCommand cmd;
            try
            {
                string query = @"SELECT Marks_Obtained, CourseID FROM Grader WHERE ParticipantID='" + psno + "'";
                cmd = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    lstCours.Add(
                        new GraderDTO
                        {
                            CourseID = dataReader["CourseID"].ToString(),
                            Marks_Obtained = Convert.ToInt32(dataReader["Marks_Obtained"].ToString())
                        });
                }
                return lstCours;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
