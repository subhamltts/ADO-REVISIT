﻿using System;
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
        }

        /*public List<FacultyDTO> GetFacultyByName()
        {
        }*/

    }
}
