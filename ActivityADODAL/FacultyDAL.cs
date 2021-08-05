using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityADODTO;

namespace ActivityADODAL
{
    public class FacultyDAL
    {
        SqlConnection sqlConnection;
        SqlCommand cmd;
        public FacultyDAL()                                 //Class Constructor
        {
            sqlConnection = DatabaseConn.ConnectToDB();     //Call static ConnectToDB() from DBConnection class to establish conn
        }

        public List<FacultyDTO> GetAllFaculty()
        {
            List<FacultyDTO> listFaculty = new List<FacultyDTO>();
            try
            {
                
                string query = @"SELECT FacultyName, EmailID, PSNo FROM Faculty";
                cmd = new SqlCommand(query, sqlConnection);

                
                //cmd.Connection = sqlConnection;
                //cmd.CommandText = @"SELECT FacultyName, EmailID, PSNo FROM Faculty";
                //cmd.CommandType = System.Data.CommandType.Text;

                sqlConnection.Open();

                SqlDataReader drFaculty = cmd.ExecuteReader();
                while (drFaculty.Read())
                {
                    // method 1
                    //FacultyDTO facultyDTO = new FacultyDTO();
                    //facultyDTO.FacultyName = drFaculty["FacultyName"].ToString();
                    //facultyDTO.EmailID = drFaculty["EmailID"].ToString();
                    //facultyDTO.PSNo = drFaculty["PSNo"].ToString();
                    //listFaculty.Add(facultyDTO);

                    //method 2
                    listFaculty.Add(
                        new FacultyDTO()
                        {
                            FacultyName = drFaculty["FacultyName"].ToString(),
                            EmailID = drFaculty["EmailID"].ToString(),
                            PSNo = Convert.ToInt32(drFaculty["PSNo"].ToString())
                        });
                }
                return listFaculty;
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
        public List<CourseDTO> GetCoursesByFacultyName(string facultyName)
        {
            List<CourseDTO> lstCourses = new List<CourseDTO>();
            try
            {
                cmd.CommandText = @"SELECT CourseTitle FROM Courses WHERE Owner=@fName";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@fName", facultyName);
                sqlConnection.Open();

                SqlDataReader drCourses = cmd.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(
                        new CourseDTO
                        {
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
                sqlConnection.Close();
            }
        }

        public List<CourseDTO> GetFacultyByCourseName(string courseTitle)
        {
            List<CourseDTO> lstFaculty = new List<CourseDTO>();
            try
            {
                cmd.CommandText = @"SELECT Owner FROM Courses WHERE CourseTitle=@cTitle";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@cTitle", courseTitle);
                sqlConnection.Open();

                SqlDataReader drFaculty = cmd.ExecuteReader();
                while (drFaculty.Read())
                {
                    lstFaculty.Add(
                        new CourseDTO
                        {
                            Owner = drFaculty["Owner"].ToString()
                        });
                }
                return lstFaculty;
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
  