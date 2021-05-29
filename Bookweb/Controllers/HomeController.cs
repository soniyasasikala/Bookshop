using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;



namespace Bookweb.Controllers
{
    public class HomeController : Controller
    {

        string connectionstring;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult ListBooks(Dictionary<string, string> filters)
        {
           string search = Convert.ToString(filters["searchName"]);
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("select * from Book where BookName like '%"+search+"%'", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult BooksDetails(Dictionary<string, string> filters)
       
        {
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("select * from Book where id =@id", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("id", filters["id"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetBook(Dictionary<string, string> filters)
        {
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("select * from Book where id =@id", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("id", filters["id"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveBook(FormCollection formCollection)
        {
            string jsonFilters = Request.Unvalidated.Form["postObj"];
            Dictionary<string, string> filters = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFilters);
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            int id = Convert.ToInt16(filters["id"]);
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            con.Open();
            if (id == 0)
            {
                SqlCommand com = new SqlCommand("insert into Book([BookName],[Author],[Publisher],[price]) values (@BookName,@Author,@Publisher,@price)", con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@BookName", filters["bookname"]);
                com.Parameters.AddWithValue("@Author", filters["author"]);
                com.Parameters.AddWithValue("@Publisher", filters["publisher"]);
                com.Parameters.AddWithValue("@price", filters["price"]);
                com.ExecuteNonQuery();
            }
            else
            {
                SqlCommand com = new SqlCommand("update Book set [BookName]=@BookName ,[Author] =@Author,[Publisher]=@Publisher,[Price]=@price where id =@id", con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@id", filters["id"]);
                com.Parameters.AddWithValue("@BookName", filters["bookname"]);
                com.Parameters.AddWithValue("@Author", filters["author"]);
                com.Parameters.AddWithValue("@Publisher", filters["publisher"]);
                com.Parameters.AddWithValue("@price", filters["price"]);
                com.ExecuteNonQuery();
            }

            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteBook(Dictionary<string, string> filters)
        {
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("delete from Book where id =@id", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("id", filters["id"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Details(Dictionary<string, string> filters)
        {
            connectionstring = @"Data source =LAPTOP-1S4VBKAE; Initial Catalog =BookDB; User ID = sa;password = sqlserver";
            // connectionString = "Data Source=sg1-wsq1.a2hosting.com;Initial Catalog=hattatou_royaldb;User ID=hattatou_dburoyal;Password=DBPass2020#";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand comm = new SqlCommand("select * from Book where id= @id", con);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@id", filters["id"]);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            DataTable dt2 = new DataTable();
            con.Close();
            System.Web.HttpContext.Current.Response.StatusCode = 200;
            System.Web.HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            var dt_requestlist = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(Convert.ToString(dt_requestlist), JsonRequestBehavior.AllowGet);

        }
    }
}