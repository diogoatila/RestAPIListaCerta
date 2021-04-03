using RestAPIListaCerta.Context;
using RestAPIListaCerta.Data.VO;
using RestAPIListaCerta.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestAPIListaCerta.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ListaContext _context;

        public UsuariosRepository(ListaContext context)
        {
            _context = context;
        }

        public Usuarios ValidateCredentials(UserVO user)
        {

            var pass = ComputerHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Usuarios.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass.ToString()));
        }
        public Usuarios ValidateCredentials(string userName)
        {
            return _context.Usuarios.SingleOrDefault(u => u.UserName == userName);
        }
        public bool RevokeToken(string userName)
        {
            var user = _context.Usuarios.SingleOrDefault(u => u.UserName == userName);

            if (user is null) return false;

            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
        public Usuarios RefreshUserInfo(Usuarios user)
        {
            if (!_context.Usuarios.Any(u => u.ID.Equals(user.ID))) return null;

            var result = _context.Usuarios.SingleOrDefault(u => u.ID.Equals(user.ID));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;

        }

        private string ComputerHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }


    }
}
