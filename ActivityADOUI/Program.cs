using ActivityADOBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADOUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Faculty facObj;
            try
            {
                facObj = new Faculty();
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
            Console.ReadKey();
        }
    }
}
 
