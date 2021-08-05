using ActivityADODTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADODAL
{
    public class CourseDAL
    {
        SqlConnection sqlconnection;
        SqlCommand cmd;

        public CourseDAL()
        {
            sqlconnection = DatabaseConn.ConnectToDB();

        }

        public List<CourseDTO> GetAllCourses()
        {
            List<CourseDTO> listCourses = new List<CourseDTO>();
            try
            {
                string query = @"SELECT CourseID, CourseTitle, Duration FROM Courses";
                cmd = new SqlCommand(query, sqlconnection);

                sqlconnection.Open();

                SqlDataReader drCourses = cmd.ExecuteReader();
                while (drCourses.Read())
                {
                    listCourses.Add(
                        new CourseDTO()
                        {
                            CourseID = drCourses["CourseID"].ToString(),
                            CourseTitle = drCourses["CourseTitle"].ToString(),
                            Duration = Convert.ToInt32(drCourses["Duration"].ToString())
                        });
                }
                return listCourses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public List<CourseDTO> GetCoursesByName(string coursName)
        {
            List<CourseDTO> lstCourses = new List<CourseDTO>();
            try
            {
                cmd.CommandText = @"SELECT CourseID, CourseTitle FROM Courses WHERE CourseTitle LIKE @cName";
                cmd.Connection = sqlconnection;
                cmd.Parameters.AddWithValue("@cName", coursName);
                sqlconnection.Open();

                SqlDataReader drCourses = cmd.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(
                        new CourseDTO
                        {
                            CourseID = drCourses["CourseID"].ToString(),
                            CourseTitle = drCourses["CourseTitle"].ToString()
                        });
                }
                return lstCourses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public List<CourseDTO> GetCoursesByAssesmentMode(string assessmentType)
        {
            List<CourseDTO> lstCourses = new List<CourseDTO>();
            try
            {
                string query = @"SELECT CourseID, CourseTitle FROM Courses WHERE AssessmentMode LIKE '" + assessmentType + "'";
                cmd = new SqlCommand(query, sqlconnection);

                //cmd.CommandText = @"SELECT CourseID, CourseTitle FROM Courses WHERE AssessmentMode LIKE @assesName";
                //cmd.Connection = sqlConnection;
                //cmd.Parameters.AddWithValue("@assesName", assessmentType);
                sqlconnection.Open();

                SqlDataReader drCourses = cmd.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(
                        new CourseDTO
                        {
                            CourseID = drCourses["CourseID"].ToString(),
                            CourseTitle = drCourses["CourseTitle"].ToString()
                        });
                }
                return lstCourses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

    } 
}

    
    
    




