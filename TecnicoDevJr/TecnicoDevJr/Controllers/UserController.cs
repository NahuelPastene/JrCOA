using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicoDevJr.Models;
using TecnicoDevJr.Repository;

namespace TecnicoDevJr.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(DevJrCoaContext context)
        {
            _userRepository = new UserRepository(context);
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(Usuario usuario)
        //{
        //    usuario = _userRepository.Create(usuario);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
