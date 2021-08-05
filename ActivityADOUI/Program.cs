using ActivityADOBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADOUI
{
   public class Program
    {
        static void Main(string[] args)
        {
            Faculty facObj;
            facObj = new Faculty();
            try
            {
                
                var result = facObj.FetchAllFaculty();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.FacultyName + " | " + item.EmailID + " | " + item.PSNo);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("**************************  Courses by Faculty Name  *********************");
            try
            {
                Console.WriteLine("\nEnter Faculty name to see assigned courses.");
                string name = Console.ReadLine();
                var lstCourse = facObj.GetCoursByFacName(name);
                if (lstCourse != null)
                {
                    foreach (var item in lstCourse)
                    {
                        Console.WriteLine(item.CourseTitle);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n**************************   Faculties Name by Course Title  *********************");
            try
            {
                Console.WriteLine("Enter Course Title to see assigned Faculties.");
                string courseTitle = Console.ReadLine();
                var lstFaculties = facObj.GetFacultyNameByCourse(courseTitle);
                if (lstFaculties != null)
                {
                    foreach (var item in lstFaculties)
                    {
                        Console.WriteLine(item.Owner);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            

           Console.WriteLine("\n\n**************  All The Courses details  ****************");
            Course courseObj = new Course();

            try
            {
                var cours = courseObj.FetchAllCourses();
                if (cours != null)
                {
                    foreach (var item in cours)
                    {
                        Console.WriteLine(item.CourseID + " | " + item.CourseTitle + " | " + item.Duration);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n\n**************  Course details By Title  ****************");
            try
            {
                Console.WriteLine("Enter Course title.");
                string coursTitle = Console.ReadLine();
                var coursesDetails = courseObj.FetchCoursesByName(coursTitle);
                if (coursesDetails != null)
                {
                    foreach (var item in coursesDetails)
                    {
                        Console.WriteLine(item.CourseID + " | " + item.CourseTitle);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("\n\n**************  Course details By AssessmentMode  ****************");
            try
            {
                Console.WriteLine("Enter Assessment Mode type.");
                string assessmentType = Console.ReadLine();
                var coursesDet = courseObj.FetchCoursesByAssessmentMode(assessmentType);
                if (coursesDet != null)
                {
                    foreach (var item in coursesDet)
                    {
                        Console.WriteLine(item.CourseID + " | " + item.CourseTitle);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\n**************  Total Participants and the score of specified Course   ****************");
            Grader graderObj = new Grader();
            try
            {
                Console.WriteLine("Enter CourseID to see Participants and score.");
                string coursID = Console.ReadLine();
                var participantList = graderObj.GetCoursParticipant(coursID);
                if (participantList != null)
                {
                    foreach (var item in participantList)
                    {
                        Console.WriteLine(item.ParticipantID + " | " + item.Marks_Obtained);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine("Enter PSNo to see Courses and score.");
                int psno = Convert.ToInt32(Console.ReadLine());
                var scorList = graderObj.GetCoursOfParticipant(psno);
                if (scorList != null)
                {
                    foreach (var item in scorList)
                    {
                        Console.WriteLine(item.CourseID + " | " + item.Marks_Obtained);
                    }
                }
                else
                {
                    Console.WriteLine("There is no data availble!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wend wrong:(");
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
    }

 
