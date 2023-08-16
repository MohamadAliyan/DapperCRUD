using DapperCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    public class CustomerControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Addresses(int id)
        {
            return View();
        }

    }
}
