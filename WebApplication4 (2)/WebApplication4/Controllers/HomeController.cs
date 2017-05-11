using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection dbconnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\media_ch\\Documents\\Visual Studio 2015\\Projects\\WebApplication4\\WebApplication4\\App_Data\\SD.mdf';Integrated Security=True");

        public object DatabaseFactory { get; private set; }

        public ActionResult Index()
        {
            //using (var context = new SDEntities())
            //{
            //    var adminId = context.UserAccount.ToList();
            //}

            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Road()
        {
            return View();
        }

        public ActionResult Product_Buy1()
        {
            // 데이터 입력

            using (dbconnection)
            {
                dbconnection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Product", dbconnection);
                SqlDataReader reader = command.ExecuteReader();
                var list = new List<Product>();

                while (reader.Read())
                {
                    var product = new Product();
                    var readint = reader.GetInt32(0);
                    var readstring = reader.GetString(1);
                    var readstring1 = reader.GetString(2);
                    var readstring2 = reader.GetString(3);
                    product.Index = readint;
                    product.Name = readstring;
                    product.Price = readstring1;
                    product.Img = readstring2;
                    list.Add(product);
                }
                ViewBag.Product = list;
            }
            return View();
        }

        public ActionResult Product_Buy2(string name, string price, string img)
        {
            return View();
        }

        public ActionResult Product2_Buy1(string name, string price, string img)
        {
            // 데이터 입력
            using (dbconnection)
            {
                dbconnection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Product2", dbconnection);
                SqlDataReader reader = command.ExecuteReader();
                var list = new List<Product2>();

                while (reader.Read())
                {
                    var product2 = new Product2();
                    var readint = reader.GetInt32(0);
                    var readstring = reader.GetString(1);
                    var readstring1 = reader.GetString(2);
                    var readstring2 = reader.GetString(3);
                    product2.Index2 = readint;
                    product2.Name2 = readstring;
                    product2.Price2 = readstring1;
                    product2.Img2 = readstring2;
                    list.Add(product2);
                }
                ViewBag.Product2 = list;
            }
            return View();
        }

        public ActionResult Product2_Buy2(string name, string price, string img)
        {
            return View();
        }

        public ActionResult Cart(int index)
        {
            using (dbconnection)
            {
                //데이터 읽기
                dbconnection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM (SELECT Product_index FROM Cart WHERE User_index=" + index + ") as a INNER JOIN Product ON Product.[Index]=a.Product_index;", dbconnection);
                SqlDataReader reader = command.ExecuteReader();
                var cart = new List<Product>();

                while (reader.Read())
                {
                    var cartproduct = new Product();
                    cartproduct.Index = reader.GetInt32(1);
                    cartproduct.Name = reader.GetString(2);
                    cartproduct.Price = reader.GetString(3);
                    cartproduct.Img = reader.GetString(4);
                    cart.Add(cartproduct);
                }
                ViewBag.Cart = cart;
                return View();
            }
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult Agreement()
        {
            return View();
        }

        public ActionResult Personalprotect()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}