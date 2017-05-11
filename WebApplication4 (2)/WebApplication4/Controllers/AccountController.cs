using System.Data.SqlClient;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        private SqlConnection dbconnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\media_ch\\Documents\\Visual Studio 2015\\Projects\\WebApplication4\\WebApplication4\\App_Data\\SD.mdf';Integrated Security=True");

        public ActionResult Register(string name, string id, string password, string confirm, string agree)
        {
            // 예외 처리
            if (name == null || id == null || password == null || confirm == null)
            {
                return View();
            }

            if (agree == null)
            {
                return View();
            }

            if (password != confirm)
            {
                return View();
            }

            // 데이터 입력
            using (dbconnection)
            {
                dbconnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO UserAccount(Id,Password,Name) VALUES('" + id + "','" + password + "','" + name + "');", dbconnection);
                var test = command.ExecuteNonQuery();
            }

            //var path = Server.MapPath("~/Data/account.json");
            //var file = new FileInfo(path);

            //using (var fileStream = file.Open(FileMode.Open, FileAccess.ReadWrite))
            //using (var streamReader = new StreamReader(fileStream))
            //using (var jsonReader = new JsonTextReader(streamReader))
            //{
            //    var jsonSerializer = JsonSerializer.Create();

            //    var accountList = jsonSerializer.Deserialize<List<UserInformation>>(jsonReader);
            //    if (accountList.Count(a => a.Id == id) > 0)
            //    {
            //    }
            //}
            return View();
        }

        //로그인을 처리하는 부분
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string id, string password)
        {
            //아이디와 패스워드가 빌 경우
            if (id == null || password == null)
            {
                return View();
            }
            else
            {
                using (dbconnection)
                {
                    dbconnection.Open();
                    SqlCommand command = new SqlCommand("SELECT Password, [Index] FROM UserAccount Where Id='" + id + "';", dbconnection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (password == reader[0].ToString())
                        {
                            Session["Login"] = "success";
                            Session["Index"] = reader[1].ToString();
                            return Redirect("/");
                        }
                    }
                    return View();
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session["Login"] = "fail";
            return Redirect("/");
        }

        //로그인 페이지를 띄워주는 부분
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}