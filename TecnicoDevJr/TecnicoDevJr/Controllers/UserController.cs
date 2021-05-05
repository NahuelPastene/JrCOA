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
        public IActionResult Index()
        {
            var user = _userRepository.GetAll().OrderBy(o => o.IdUsuario);
            return View(user);
        }
        public IActionResult Delete(int Id)
        {
            Usuario usuario = _userRepository.GetById(Id);
            _userRepository.Delete(usuario);
            _userRepository.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("Edit",new Usuario());
        }
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
                var usuario = _userRepository.GetById(id);
                return View(usuario);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                    _userRepository.Create(usuario);
                    _userRepository.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetById(usuario.IdUsuario);
                if (user != null)
                {
                    user.UserName = usuario.UserName;
                    user.Nombre = usuario.Nombre;
                    user.Email = usuario.Email;
                    user.Telefono = usuario.Telefono;
                    _userRepository.Edit(user);
                    _userRepository.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
    }
}
