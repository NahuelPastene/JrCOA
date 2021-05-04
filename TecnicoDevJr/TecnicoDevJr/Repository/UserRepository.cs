using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicoDevJr.Models;

namespace TecnicoDevJr.Repository
{
    public class UserRepository
    {
        private readonly DevJrCoaContext _context;
        public UserRepository(DevJrCoaContext context)
        {
            _context = context;
        }
        public void Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }
        public void Edit(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }
        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public Usuario GetById(int Id)
        {
            Usuario usuario = _context.Usuarios.Where(x => x.IdUsuario == Id).FirstOrDefault();
            return usuario;
        }
        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        internal void GetById(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
