using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Data.SqlClient;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectonString()
        {
            con.ConnectionString = "Server=hopdatabasear.cddp0thyxvho.eu-west-2.rds.amazonaws.com,1433\\Catalog=WebsiteTest; Database=WebsiteTest; User=ARadmin; Password=ARd4t4b4s3;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectonString();
            con.Open();
            com.Connection = con;
           com.CommandText = "select * from tblLogin where Email='"+acc.Name+"' and Password='"+acc.Password+"'";
           // com.CommandText = "INSERT INTO tblLogin(Email,Password) values('+acc.Name+','+acc.Password+')";

            //User this query for adding a key in the database
            //concept: 1.adding a random key in the special key column
            //2.When the buy button is triggered the specific row will generate a random key in the special key column
            //com.CommandText = "INSERT INTO tblLogin(SpecialKey) values('#e45c62km')";

            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}