using Microsoft.Extensions.Configuration;
using SistemaConsultorio.Models;
using SistemaConsultorio.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.DAL
{
    public class UsuarioRepositorySqlServer : IDefautRepository<Usuarios>
    {
        private Usuarios _usuario = new Usuarios();
        private IConfiguration _configuration { get; set; }
        private ConexaoSql _conexaoSql { get; set; }

        public UsuarioRepositorySqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
            _conexaoSql = new ConexaoSql(_configuration);
        }

        public Usuarios Autenticar(LoginViewModel login)
        {
            var resultado = _conexaoSql.ExecuteReader($"SELECT TOP 1 Id,Usuario,Senha,Email,Nome FROM Usuarios WHERE Usuario = '{login.Usuario}' and Senha = '{login.Senha}'");

            foreach (DataRow row in resultado.Rows)
            {
                _usuario.Usuario = row["Usuario"].ToString();
                _usuario.Senha = row["Senha"].ToString();
                _usuario.Email = row["Email"].ToString();
                _usuario.Nome = row["Nome"].ToString();
                _usuario.Id = int.Parse(row["Id"].ToString());
            }

            return _usuario;
        }

        public Usuarios Atualizar(Usuarios item)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Usuarios Inserir(Usuarios item)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuarios SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
