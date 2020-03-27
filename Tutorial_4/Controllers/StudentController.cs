using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tutorial4.Models;
using System.Data.SqlClient;
using System.Globalization;
using com.sun.org.apache.bcel.@internal.generic;
using java.lang;
using java.sql;
using Microsoft.AspNetCore.Identity;
using String = System.String;


[ApiController]
    [Route("api/students")]
    
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult getStudent()
        {
            using (var client =
                new SqlConnection("Data Source=db-mssql;Initial Catalog=s18588;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "select * from student,Enrollment,studies join Enrollment E on Studies.IdStudy = E.IdStudy join Studies S on E.IdStudy = S.IdStudy;";
                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.ParseExact(dr["BirthDate"].ToString(),"yyyy-MM-dd HH:mm",CultureInfo.InvariantCulture);
                    st.Studies = dr["Studies.Name"].ToString();
                    st.Semester = Integer.parseInt(dr["Enrollment.Semester"].ToString());
                    return Ok(st);
                }
                return null;

            }

        }
        

        [HttpPost]
        public IActionResult CreateStudent()
        {
            var s = new Student();
            // s.IndexNumber = $"s{new Random().Next(1, 2000)}";
            s.IdStudent = 1;
            s.FirstName = "A";
            s.LastName = "B";
            return Ok(s);
        }

        [HttpPut]
        public IActionResult putStudent()
        {
            var s = new Student();
            // s.IndexNumber = $"s{new Random().Next(1, 2000)}";
            s.IdStudent = 1;
            s.FirstName = "A";
            s.LastName = "B";
            return Ok(s);
        }

        [HttpDelete]
        public IActionResult removeStudent(int id)
        {
            
            return Ok(id);
        }
    }
