using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Student()
        {
            return View();
        }
        public List<StudentModel> students = new List<StudentModel>();
        public string info = "Hello student info";
        public IActionResult Index()
        {
            try
            {
                string connString = "Data Source=5CG7324TYL;Initial Catalog = TryDB; Encrypt=False; Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from StudentInfo";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StudentModel sm = new StudentModel();

                    sm.studentId = (int)reader["studentId"];
                    sm.studentName = (string)reader["studentName"];
                    sm.studentDept = (string)reader["studentDept"];
                    students.Add(sm);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewData["list_of_students"] = students;
            
            //string connectionString = "Data Source=5CG7324TYL;Initial Catalog = TryDB; Encrypt=False; Integrated Security=True;";

            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandText = "SELECT * FROM dbo.StudentInfo";

            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    StudentModel s1 = new StudentModel();


            //    s1.studentId = reader.GetInt32((0));
            //    s1.studentName = "" + reader[1];
            //    s1.studentDept = "" + reader[2];

            //    students.Add(s1);
            //}

            //ViewBag.students = students;
            ViewBag.info = info;


            return View();
        }
    }
}
