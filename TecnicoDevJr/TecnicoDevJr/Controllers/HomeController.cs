using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TecnicoDevJr.Models;
using TecnicoDevJr.Repository;

namespace TecnicoDevJr.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        public HomeController(DevJrCoaContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public IActionResult Index()
        {
            var user =_userRepository.GetAll().OrderBy(o => o.IdUsuario);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
