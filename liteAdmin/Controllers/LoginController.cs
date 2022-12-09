using BusinessLogic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHASecureAlgorithm;


namespace liteAdmin.Controllers
{
    // [Authorize]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext db;
        public LoginController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginView(UserCredentials u)
        {

            try
            {

                var credentials = db.UserCredentials.Where(m => m.Name == u.Name &&
               m.Password == Sha512.SecureAlgorithm(u.Password)).FirstOrDefault();

                if (credentials != null)
                {
                    HttpContext.Session.SetString("username", u.Name);
                    HttpContext.Session.SetString("password", u.Password);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Login Failed , Invalid Username/Password";
                }
            }
            catch (Exception)
            {

            }


            return RedirectToAction("");





        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCredentials u)
        {

            try
            {

                //Users users = new Users();
                UserCredentials users = new UserCredentials();
             
                users.UserId = u.UserId;
                users.Password = Sha512.SecureAlgorithm(u.Password);
                users.plainPassword = u.Password;
                users.LoginId = u.LoginId;
                users.IsBLock = u.IsBLock;
                users.CreatedBy = u.CreatedBy;
                users.LoginRetryCount = u.LoginRetryCount;
                users.MaxTry = u.MaxTry;
                users.IsUserLogedin = u.IsUserLogedin;
                users.CreatedOn = DateTime.Now;
                users.LastLoginTime = u.LastLoginTime;
                users.Name = u.Name;
               
                
                var add = db.UserCredentials.Add(users);  

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //if session null then redirect to login
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await db.users.ToListAsync();

            return View(list);

        }



        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {



            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("password");
            HttpContext.Session.Clear();

            return RedirectToAction("LoginView", "Login");
        }

    }
}
